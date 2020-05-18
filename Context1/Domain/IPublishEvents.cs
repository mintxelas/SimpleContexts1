using System.Collections.Generic;

namespace Context1.Domain
{
    public interface IPublishEvents
    {
        List<object> GetEvents();
        void ClearEvents();
    }
}