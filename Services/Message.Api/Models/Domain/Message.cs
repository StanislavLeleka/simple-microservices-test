using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Message.Models.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }

        private IList<string> _recipients;

        [NotMapped]
        public IList<string> Recipients
        {
            set { _recipients = value; }
            get => _recipients ?? new List<string>();
        }
    }
}
