using System;
using Microsoft.AspNetCore.Mvc;
using Message.Models.ViewModels;
using Message.Services;
using System.Threading.Tasks;

namespace Message.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(MessageService));
        }        

        [Route("send")]
        [HttpPost]
        public async Task<int> SendMessage([FromBody]MessageItem message)
        {
            return await _messageService.SaveMessage(message);
        }
    }
}
