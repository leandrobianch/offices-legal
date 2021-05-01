using System.Threading.Tasks;

namespace OfficesLegal.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
