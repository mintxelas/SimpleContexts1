using System.Threading.Tasks;
using Context2.Domain;

namespace Context2.Infrastructure
{
    public class RepositoryWithBus: IRepository<RepositoryWithBus>
    {
        private readonly Messaging.Common.IMessaging bus;

        public RepositoryWithBus(Messaging.Common.IMessaging bus)
        {
            this.bus = bus;
        }

        public Processor Get()
        {
            return new Processor();
        }

        public async Task SaveAsync(Processor processor)
        {
            var publisher = processor as IPublishEvents;
            foreach (var @event in publisher.GetEvents())
            {
                await bus.Publish(@event);
            }
            
            publisher.ClearEvents();

            // Save processor
        }
    }
}