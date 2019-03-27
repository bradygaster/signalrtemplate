using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRTemplate.Hubs;
using SignalRTemplate.Services;

namespace SignalRTemplate.Workers
{
    public class ServerClock : BackgroundService
    {
        public ServerClock(IHubContext<ServerTimeHub, IClock> serverTimeHub)
        {
            ServerTimeHub = serverTimeHub;
        }

        private IHubContext<ServerTimeHub, IClock> ServerTimeHub { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ServerTimeHub.Clients.All.SendTime(DateTime.UtcNow);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}