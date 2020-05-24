using Context2.Application;
using Context2.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Context2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinController: ControllerBase
    {
        private readonly ApplicationService<RepositoryWithSubscribers> service;

        public SinController(ApplicationService<RepositoryWithSubscribers> service)
        {
            this.service = service;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello (call in service) - " + service.DoSomething();
        }
    }
}