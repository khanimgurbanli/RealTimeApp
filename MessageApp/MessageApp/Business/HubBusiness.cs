using MessageApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MessageApp.Business
{
    public class HubBusiness
    {
       private readonly IHubContext<HubAction> _context;

        public HubBusiness(IHubContext<HubAction>hubContext)
        {
            _context = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _context.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
