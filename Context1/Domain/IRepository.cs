namespace Context1.Domain
{
    public interface IRepository<T> where T: class, IRepository<T>
    {
        Processor Get();
        void Save(Processor processor);
    }
}