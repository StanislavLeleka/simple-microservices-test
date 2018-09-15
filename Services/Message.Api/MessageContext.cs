using Microsoft.EntityFrameworkCore;
using Message.Models.Domain;

namespace Message
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> contextOptions) : base(contextOptions) { }

        public DbSet<Models.Domain.Message> Messages { get; set; }
    }
}
