using Context1.Domain;

namespace Context1.Infrastructure
{
    public class Repository : IRepository<Repository>
    {
        public Processor Get()
        {
            return new Processor();
        }

        public void Save(Processor processor)
        {
            // Save processor
        }
    }
}