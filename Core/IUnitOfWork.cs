using System.Threading.Tasks;

namespace ProcessHub.Core
{
    public interface IUnitOfWork
    {
            Task CompleteAsync();
    }
}