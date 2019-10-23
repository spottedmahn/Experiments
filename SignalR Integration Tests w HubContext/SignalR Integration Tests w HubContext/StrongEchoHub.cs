using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR_Integration_Tests_w_HubContext
{
    public class StrongEchoHub : Hub<IStrongEchoHub>
    {
        public async Task SendFromHub(string message)
        {
            await Clients
                .All
                .OnMessageRecievedFromHub(message);
        }
    }
}
