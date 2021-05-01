using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OfficesLegal.Api.Configurations
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerGenConfigureServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Api Committee Management",
                    Version = Assembly.GetExecutingAssembly().GetInformationalVersion(),
                    Description = $"Api Committee Management",
                });
            });
        }

        public static string GetInformationalVersion(this Assembly assembly)
        {
            var assemblyFileVersionAttribute = (AssemblyInformationalVersionAttribute)assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true).FirstOrDefault();
            return assemblyFileVersionAttribute?.InformationalVersion;
        }

        public static IApplicationBuilder UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(0);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfficesLegal V1");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
