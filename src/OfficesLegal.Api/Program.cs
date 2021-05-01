using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficesLegal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostContext, configurationBuilder) =>
                {
                    var env = hostContext.HostingEnvironment;
                    configurationBuilder.AddJsonFile("appsettings.json", true, true);
                    configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                    configurationBuilder.AddEnvironmentVariables();
                    if (args != null)
                    {
                        configurationBuilder.AddCommandLine(args);
                    }

                    if (env.IsDevelopment())
                    {
                        configurationBuilder.AddUserSecrets<Program>();
                    }
                });
    }
}
