using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficesLegal.Api.Configurations.HealthCheck;
using OfficesLegal.Api.Filters;
using OfficesLegal.Application;
using OfficesLegal.Application.ProcessCases;
using OfficesLegal.Common;
using OfficesLegal.Domain.ProcessCases;
using OfficesLegal.Infra.Data.Repository;

namespace OfficesLegal.Api.Configurations
{
    public static class IocExtensions
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                //options.RespectBrowserAcceptHeader = true;
                //options.Filters.Add(new ProducesAttribute("application/json"));
                //options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(new ModelStateValidationsFilter());
                options.Filters.Add(new NotificationsValidationFilter());
                //options.FormatterMappings.ClearMediaTypeMappingForFormat("application/xml");
                //options.InputFormatters.Clear();
                //options.OutputFormatters.Clear();
            }).ConfigureApiBehaviorOptions(options =>
            {
                //options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddDbContextConfigureServices(configuration);
            services.AddSwaggerGenConfigureServices();
            services.AddScoped<IProcessCaseRepository, ProcessCaseRepository>();
            services.AddScoped<IProcessCaseService, ProcessCaseService>();
            services.AddScoped<INotificationValidation, NotificationValidation>();
            services.AddHealthCheckConfigureServices();
        }
    }
}
