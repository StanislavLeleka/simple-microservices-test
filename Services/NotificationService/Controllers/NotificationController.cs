using Microsoft.AspNetCore.Mvc;
using NotificationService.Hubs;
using NotificationService.Models;
using System.Threading.Tasks;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IMessageHub _messageHub;

        public NotificationController(IMessageHub messageHub)
        {
            _messageHub = messageHub;
        }

        [Route("receive-message")]
        [HttpPost]
        public async Task SendMessage([FromBody]MessageNotificationDto message)
        {
            await _messageHub.NotifyClients(message);
        }
    }
}
