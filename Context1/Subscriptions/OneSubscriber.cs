﻿using Context1.Domain;
using Messaging.Common;
using Microsoft.Extensions.Logging;
using System;
using SharedEvents;

namespace Context1.Subscriptions
{
    public class OneSubscriber
    {
        private readonly ILogger<OneSubscriber> logger;
        private readonly IMessaging bus;

        public OneSubscriber(ILogger<OneSubscriber> logger, IMessaging bus)
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