using System.Threading.Tasks;
using Context2.Domain;

namespace Context2.Infrastructure
{
    public class Repository : IRepository<Repository>
    {
        public Processor Get()
        {
            return new Processor();
        }

        public Task SaveAsync(Processor processor)
        {
            // Save processor
            return Task.CompletedTask;
        }
    }
}