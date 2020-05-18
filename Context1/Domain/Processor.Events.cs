using System.Collections.Generic;

namespace Context1.Domain
{
    public partial class Processor : IPublishEvents
    {
        private readonly List<object> pendingEvents = new List<object>();

        void IPublishEvents.ClearEvents()
        {
            pendingEvents.Clear();
        }

        List<object> IPublishEvents.GetEvents()
        {
            return pendingEvents;
        }
    }
}
