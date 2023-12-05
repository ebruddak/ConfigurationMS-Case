using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceA.Consumers;

namespace ServiceA
{

    public class Program
    {

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var Listener = serviceProvider.GetService(typeof(EventBusConfigurationCreateConsumer)) as EventBusConfigurationCreateConsumer;
                var life = serviceProvider.GetService(typeof(IHostApplicationLifetime)) as IHostApplicationLifetime;

                Listener.Consume();




            }

            Console.WriteLine($"SignalR istemciden gelen mesaj: burda");

            var hubConnection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:5011/ConfigurationHub")
                 .Build();

            hubConnection.On<string>("ReceiveMessage", (message) =>
            {

                Console.WriteLine($"SignalR istemciden gelen mesaj: {message}");
            });



            try
            {
                await hubConnection.StartAsync();

                while (true)
                {
                    await hubConnection.SendAsync("AddToGroup", AppDomain.CurrentDomain.FriendlyName);

                    Console.WriteLine("SignalR istemci başlatıldı. Mesaj bekleniyor...");


                    await Task.Delay(TimeSpan.FromMinutes(1));
                }

                var response = await hubConnection.InvokeAsync<string>("ReceiveNotification");

                Console.WriteLine($"Hub metodu çağrıldı, cevap: {response}");

                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Mesaj bulunamadı");
                }
                else
                {
                    Console.WriteLine("Mesaj bulundu, configrasyon değişmiş.");

                }


            }
            catch
            {

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
