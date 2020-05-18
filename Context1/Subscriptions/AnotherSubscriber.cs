using Context1.Domain;
using Context1.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Context1.Subscriptions
{
    public class AnotherSubscriber
    {
        private readonly ILogger<AnotherSubscriber> logger;
        private readonly Bus bus;

        private int counter;

        public AnotherSubscriber(ILogger<AnotherSubscriber> logger, Bus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        public void InitializeSubscriptions()
        {
            bus.Subscribe<SomeEvent>(DoSomething);
        }

        public void DoSomething(SomeEvent @event)
        {
            counter += 1;
            logger.LogInformation("Received {Counter} events", counter);
        }
    }
}