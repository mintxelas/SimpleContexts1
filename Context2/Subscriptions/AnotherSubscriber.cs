using Messaging.Common;
using Microsoft.Extensions.Logging;
using SharedEvents;

namespace Context2.Subscriptions
{
    public class AnotherSubscriber
    {
        private readonly ILogger<AnotherSubscriber> logger;
        private readonly IMessaging bus;

        private int counter;

        public AnotherSubscriber(ILogger<AnotherSubscriber> logger, IMessaging bus)
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