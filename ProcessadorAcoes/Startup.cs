using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;
using ProcessadorAcoes.Data;

namespace ProcessadorAcoes
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            services.AddSingleton(logger);

            logger.Information("Carregando configurações...");
            
            var configAppSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json").Build();
                        
            var configuration = new ConfigurationBuilder()
                .AddAzureAppConfiguration(
                    configAppSettings.GetConnectionString("AppConfiguration"))
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<AcoesRepository>();

            services.AddTransient<ConsoleApp>();
        }   
    }
}