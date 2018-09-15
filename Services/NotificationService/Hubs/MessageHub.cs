using Microsoft.AspNetCore.SignalR;
using NotificationService.Models;
using System.Threading.Tasks;

namespace NotificationService.Hubs
{
    public class MessageHub : Hub, IMessageHub
    {
        protected IHubContext<MessageHub> _context;

        public MessageHub(IHubContext<MessageHub> context)
        {
            _context = context;
        }

        public async Task NotifyClients(MessageNotificationDto message)
        {
            foreach (var recipient in message.Recipients)
            {
                await _context.Clients.All.SendAsync("ReceiveMessage", recipient, message.Body);
            }
        }
    }
}
