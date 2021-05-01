using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OfficesLegal.Api.Configurations.Configurations.HealthCheck;
using OfficesLegal.Infra.Data.EF;
using System;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace OfficesLegal.Api.Configurations.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static void AddHealthCheckConfigureServices(this IServiceCollection services)
        {
            services.AddHealthChecks()
                    .AddCheck<DatabaseHealthCheck>($"{nameof(DatabaseContext)}");
            services.AddHealthChecksUI()
                    .AddInMemoryStorage();
        }

        public static IApplicationBuilder UseHealthCheckConfigure(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/status", new HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(
                        new
                        {
                            statusApplication = report.Status.ToString(),
                            healthChecks = report.Entries.Select(e => new
                            {
                                check = e.Key,
                                ErrorMessage = e.Value.Exception?.Message,
                                status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                            })
                        });
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });

            app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(configuration =>
            {
                configuration.UIPath = "/hci";
            });
            return app;
        }
    }
}
