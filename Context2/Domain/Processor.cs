﻿using SharedEvents;

namespace Context2.Domain
{
    public partial class Processor
    {
        public void Process()
        {
            //Do something
            pendingEvents.Add(new SomeEvent());
        }
    }
}