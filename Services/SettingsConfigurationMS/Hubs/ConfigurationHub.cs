

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SettingsConfigurationMS.Hubs;

namespace SettingsConfigurationMS.Hubs
{
    public class ConfigurationHub : Hub
    {

        public async Task SendNotificationToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveNotification", message);
        }

    }
}