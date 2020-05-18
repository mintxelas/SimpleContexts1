using Context1.Domain;

namespace Context1.Infrastructure
{
    public class RepositoryWithBus: IRepository<RepositoryWithBus>
    {
        private readonly Bus bus;

        public RepositoryWithBus(Bus bus)
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
            publisher.GetEvents().ForEach(bus.Publish);
            publisher.ClearEvents();

            // Save processor
        }
    }
}