using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SettingsConfigurationMS.Hubs
{
    public class IHubClient
    {
        Task InformClient(string message);

    }
}