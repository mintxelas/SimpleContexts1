using System.Threading.Tasks;
using Context2.Domain;
using Context2.Subscriptions;
using SharedEvents;

namespace Context2.Infrastructure
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

        public Task SaveAsync(Processor processor)
        {
            var @event = new SomeEvent();
            subscriber1.DoSomething(@event);
            subscriber2.DoSomething(@event);
            
            // Save processor

            return Task.CompletedTask;
        }
    }
}