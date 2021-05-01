using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OfficesLegal.Infra.Data.EF;
using System;
using System.Reflection;

namespace OfficesLegal.Api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .AddJsonFile("appsettings.json", true, true)
                                    .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                                    .AddUserSecrets<DbFactoryDbContext>()
                                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(DatabaseContext).GetTypeInfo().Assembly.GetName().Name));
            var databaseContext = new DatabaseContext(optionsBuilder.Options);
            return databaseContext;
        }
    }
}
