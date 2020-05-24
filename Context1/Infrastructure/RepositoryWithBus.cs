using Context1.Domain;
using Messaging.Common;

namespace Context1.Infrastructure
{
    public class RepositoryWithBus: IRepository<RepositoryWithBus>
    {
        private readonly IMessaging bus;

        public RepositoryWithBus(IMessaging bus)
        {
            this.bus = bus;
        }

        public Processor Get()
        {
            return new Processor();
        }

        public void Save(Processor processor)
        {
            var publisher = processor as IPublishEvents;
            publisher.GetEvents().ForEach(x => bus.Publish(x).Wait());
            publisher.ClearEvents();

            // Save processor
        }
    }
}