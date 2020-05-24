using Context2.Application;
using Context2.Domain;
using Context2.Infrastructure;
using Context2.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using SharedEvents;

namespace Context2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaleteController : ControllerBase
    {
        private readonly ApplicationService<Repository> service;
        private readonly OneSubscriber subscriber1;
        private readonly AnotherSubscriber subscriber2;

        public FaleteController(ApplicationService<Repository> service, OneSubscriber subscriber1, AnotherSubscriber subscriber2)
        {
            this.service = service;
            this.subscriber1 = subscriber1;
            this.subscriber2 = subscriber2;
        }

        [HttpGet]
        public string Get()
        {
            var result = "Hello (with direct call) - " + service.DoSomething();
            var @event = new SomeEvent();
            subscriber1.DoSomething(@event);
            subscriber2.DoSomething(@event);
            return result;
        }
    }
}