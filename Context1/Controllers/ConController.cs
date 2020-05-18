using Context1.Application;
using Context1.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Context1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConController: ControllerBase
    {
        private readonly ApplicationService<RepositoryWithBus> service;

        public ConController(ApplicationService<RepositoryWithBus> service)
        {
            this.service = service;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello (with events) - " + service.DoSomething();
        }
    }
}