using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Client;

namespace ServiceA
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            Connect().Wait();
            var hubConnection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:44398/configurationhub")
                 .Build();

            hubConnection.On<string>("ReceiveMessage", (message) =>
            {

                Console.WriteLine($"SignalR istemciden gelen mesaj: {message}");
            });

            try
            {
                await hubConnection.StartAsync();
                Console.WriteLine("SignalR istemci başlatıldı. Mesaj bekleniyor...");

                var response = await hubConnection.InvokeAsync<string>("UpdateSetting");

                Console.WriteLine($"Hub metodu çağrıldı, cevap: {response}");

                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Mesaj bulunamadı");
                }
                else
                {
                    var serviceProvider = new ServiceCollection()
           .AddSingleton<EventBusConfigurationCreateConsumer>()
           .BuildServiceProvider();

                    var eventBusConsumer = serviceProvider.GetService<EventBusConfigurationCreateConsumer>();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SignalR istemci başlatılırken hata oluştu: {ex.Message}");
            }

            await hubConnection.StopAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
