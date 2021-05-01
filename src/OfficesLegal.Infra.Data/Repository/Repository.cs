using OfficesLegal.Common;
using OfficesLegal.Infra.Data.EF;
using System.Threading.Tasks;

namespace ProcessCase.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork => DatabaseContext;
        protected DatabaseContext DatabaseContext { get; }
        public Repository(IUnitOfWork unitOfWork)
        {
            DatabaseContext = (DatabaseContext)unitOfWork;
        }

        public void Delete(TEntity entity)
        {
            DatabaseContext.Remove(entity);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await DatabaseContext.FindAsync<TEntity>(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DatabaseContext.AddAsync(entity);
        }
    }
}
