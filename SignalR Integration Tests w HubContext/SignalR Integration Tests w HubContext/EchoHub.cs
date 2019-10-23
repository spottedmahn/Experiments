using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR_Integration_Tests_w_HubContext
{
    public class EchoHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients
                .Caller
                .SendAsync("OnMessageRecieved", message);
        }
    }
}
