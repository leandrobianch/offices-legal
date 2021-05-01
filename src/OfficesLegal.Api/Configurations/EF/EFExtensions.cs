using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficesLegal.Common;
using OfficesLegal.Infra.Data.EF;
using System;
using System.Reflection;

namespace OfficesLegal.Api.Configurations
{
    public static class EFExtensions
    {
        public static void AddDbContextConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IUnitOfWork, DatabaseContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 sqlServerOptionsAction: sqlOptions =>
                 {
                     sqlOptions.MigrationsAssembly(typeof(DatabaseContext).GetTypeInfo().Assembly.GetName().Name);
                    //Configuring Connection Resiliency:
                    sqlOptions.
                         EnableRetryOnFailure(maxRetryCount: 5,
                         maxRetryDelay: TimeSpan.FromSeconds(30),
                         errorNumbersToAdd: null);

                 });

                // Changing default behavior when client evaluation occurs to throw.
                // Default in EFCore would be to log warning when client evaluation is done.
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
             });
        }
    }
}
