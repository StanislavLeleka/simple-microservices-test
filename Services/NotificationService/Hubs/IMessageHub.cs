using NotificationService.Models;
using System.Threading.Tasks;

namespace NotificationService.Hubs
{
    public interface IMessageHub
    {
        Task NotifyClients(MessageNotificationDto message);
    }
}
