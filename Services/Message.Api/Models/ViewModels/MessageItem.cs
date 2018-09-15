using System.Collections.Generic;

namespace Message.Models.ViewModels
{
    public class MessageItem
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
        public string[] Recipients { get; set; }
    }
}
