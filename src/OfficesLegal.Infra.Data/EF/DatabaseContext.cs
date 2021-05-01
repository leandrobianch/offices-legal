using Microsoft.EntityFrameworkCore;
using OfficesLegal.Common;
using OfficesLegal.Infra.Data.EF.Configurations;
using System.Threading.Tasks;

namespace OfficesLegal.Infra.Data.EF
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessCaseMap());
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }

        public DbSet<Domain.ProcessCases.ProcessCase> ProcessCaseLegal { get; set; }
    }
}
