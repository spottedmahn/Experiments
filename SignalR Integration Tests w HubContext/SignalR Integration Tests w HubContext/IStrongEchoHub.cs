using System.Threading.Tasks;

namespace SignalR_Integration_Tests_w_HubContext
{
    public interface IStrongEchoHub
    {
        Task OnMessageRecievedFromHubContext(string message);

        Task OnMessageRecievedFromHub(string message);
    }
}