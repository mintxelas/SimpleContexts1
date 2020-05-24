using System.Threading.Tasks;

namespace Context2.Domain
{
    public interface IRepository<T> where T: class, IRepository<T>
    {
        Processor Get();
        Task SaveAsync(Processor processor);
    }
}