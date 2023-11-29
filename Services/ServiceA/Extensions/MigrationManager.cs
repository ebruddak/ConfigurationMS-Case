
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data;
using System;

namespace ServiceA.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var settingContext = scope.ServiceProvider.GetRequiredService<SettingContext>();

                    if(settingContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        settingContext.Database.Migrate();
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return host;
        }
    }
}