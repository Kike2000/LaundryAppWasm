using Microsoft.AspNetCore.SignalR;

namespace LaundryAppWasm.Server.Helpers
{
    public class SignalRHelper : Hub
    {
        public const string HubUrl = "/signalRHub";

        public async Task Broadcast(string actionType, object target)
        {
            Console.WriteLine($"action: {actionType}");
            await Clients.All.SendAsync("Broadcast", actionType, target);
        }

        public async Task Send(string actionType, object target)
        {
            await Clients.All.SendAsync("Send", actionType, target);
        }

        public async Task SendTransactionSetup(string actionType, object target)
        {
            await Clients.All.SendAsync("SendTransactionSetup", actionType, target);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
