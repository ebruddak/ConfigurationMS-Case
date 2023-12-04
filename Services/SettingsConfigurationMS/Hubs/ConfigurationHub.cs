

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SettingsConfigurationMS.Hubs;

namespace SettingsConfigurationMS.Hubs
{
    public class ConfigurationHub : Hub<IHubClient>
    {

        public async Task UpdateSetting(string settings)
        {
            // Console.WriteLine(settings);
        }
    }
}