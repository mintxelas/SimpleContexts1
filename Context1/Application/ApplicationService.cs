using System.Threading.Tasks;
using Context1.Domain;

namespace Context1.Application
{
    public class ApplicationService<T> where T: class, IRepository<T>
    {
        private readonly IRepository<T> repository;

        public ApplicationService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public string DoSomething()
        {
            var processor = repository.Get();
            processor.Process();
            repository.Save(processor);
            return "Process finished.";
        }
    }
}