using Context2.Domain;

namespace Context2.Application
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
            repository.SaveAsync(processor);



            return "Process finished.";
        }
    }
}