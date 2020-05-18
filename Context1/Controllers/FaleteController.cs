using Context1.Application;
using Context1.Domain;
using Context1.Infrastructure;
using Context1.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace Context1.Controllers
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