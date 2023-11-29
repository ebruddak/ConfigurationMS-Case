using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SettingsConfigurationMS.Dtos;
using SettingsConfigurationMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingsConfigurationMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var settingsConfiguration = serviceProvider.GetRequiredService<ISettingsConfigurationService>();

                if (!settingsConfiguration.GetAllAsync().Result.Data.Any())
                {
                    settingsConfiguration.CreateAsync(new SettingsConfigurationDto { Name = "SiteName",Type="string" , Value="google.com",IsActive=true, ApplicationName="Service-A"}).Wait();
                    settingsConfiguration.CreateAsync(new SettingsConfigurationDto { Name = "IsBasketEnabled",Type="Boolean" , Value="1",IsActive=true, ApplicationName="Service-A"}).Wait();                
                    settingsConfiguration.CreateAsync(new SettingsConfigurationDto { Name = "MaxItemCount",Type="Int" , Value="150",IsActive=true, ApplicationName="Service-A"}).Wait();   
                }

            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
