using Context2.Application;
using Context2.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Context2.Controllers
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