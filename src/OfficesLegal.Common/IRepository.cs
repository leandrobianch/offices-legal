using System.Threading.Tasks;

namespace OfficesLegal.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        void Delete(TEntity entity);
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(int id);
    }
}
