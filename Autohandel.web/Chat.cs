using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Autohandel.web
{
    public class Chat : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}
