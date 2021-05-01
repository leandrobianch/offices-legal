using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OfficesLegal.Common;
using OfficesLegal.Infra.Data.EF;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficesLegal.Api.Configurations.Configurations.HealthCheck
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public IServiceScopeFactory ScopeFactory { get; }
        public DatabaseHealthCheck(IServiceScopeFactory scopeFactory)
        {
            ScopeFactory = scopeFactory;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using var scope = ScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<DatabaseHealthCheck>>();
            var databaseContext = (DatabaseContext)scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            try
            {
                var getPendingMigrationsAsync = await databaseContext.Database.GetPendingMigrationsAsync(cancellationToken: cancellationToken);
                if (getPendingMigrationsAsync.Any())
                {
                    await databaseContext.Database.MigrateAsync(cancellationToken: cancellationToken);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"{typeof(DatabaseHealthCheck).FullName} - {nameof(CheckHealthAsync)} error: {ex}");
                return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
            }
            return HealthCheckResult.Healthy();
        }
    }
}
