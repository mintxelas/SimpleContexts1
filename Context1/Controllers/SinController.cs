using Context1.Application;
using Context1.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Context1.Controllers
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