using System;
using Context1.Domain;
using Context1.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Context1.Subscriptions
{
    public class OneSubscriber
    {
        private readonly ILogger<OneSubscriber> logger;
        private readonly Bus bus;

        public OneSubscriber(ILogger<OneSubscriber> logger, Bus bus)
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
            logger.LogInformation("Received SomeEvent at {instant:s}", DateTime.UtcNow);
        }
}
}