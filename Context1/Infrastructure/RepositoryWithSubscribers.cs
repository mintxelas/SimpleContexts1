using Context1.Domain;
using Context1.Subscriptions;

namespace Context1.Infrastructure
{
    public class RepositoryWithSubscribers: IRepository<RepositoryWithSubscribers>
    {
        private readonly OneSubscriber subscriber1;
        private readonly AnotherSubscriber subscriber2;

        public RepositoryWithSubscribers(OneSubscriber subscriber1, AnotherSubscriber subscriber2)
        {
            this.subscriber1 = subscriber1;
            this.subscriber2 = subscriber2;
        }

        public Processor Get()
        {
            return new Processor();
        }

        public void Save(Processor processor)
        {
            var @event = new SomeEvent();
            subscriber1.DoSomething(@event);
            subscriber2.DoSomething(@event);
            // Save processor
        }
    }
}