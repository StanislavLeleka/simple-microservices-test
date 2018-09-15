using Message.Models.Domain;
using Message.Models.ViewModels;
using System.Threading.Tasks;

namespace Message.Services
{
    public interface IMessageService
    {
        Task<int> SaveMessage(MessageItem message);
    }
}
