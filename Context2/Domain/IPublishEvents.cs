using System.Collections.Generic;

namespace Context2.Domain
{
    public interface IPublishEvents
    {
        List<object> GetEvents();
        void ClearEvents();
    }
}