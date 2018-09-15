using System;
using Message.Models.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using NotificationService.Models;
using Message.API.Services;
using System.Linq;

namespace Message.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly HttpComunicationHelper _httpComunicationHelper;

        public MessageService(MessageContext messageContext)
        {
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(MessageContext));
            _httpComunicationHelper = new HttpComunicationHelper();
        }

        private async Task Notify(Models.Domain.Message message)
        {
            await _httpComunicationHelper.PostJson(JsonConvert.SerializeObject(new MessageNotificationDto {
                Body = message.Body, Recipients = message.Recipients.ToArray() }));

            message.IsSent = true;

            await _messageContext.SaveChangesAsync();
        }

        public async Task<int> SaveMessage(MessageItem message)
        {
            var newMessage = new Models.Domain.Message
            {
                Body = message.Body,
                Subject = message.Subject,
                Recipients = message.Recipients
            };

            _messageContext.Messages.Add(newMessage);

            await _messageContext.SaveChangesAsync();
            await Notify(newMessage);

            return newMessage.Id;
        }
    }
}
