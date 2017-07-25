using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Yaca.Api.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext()
        {
            if (this.Messages.Count() == 0)
            {
                this.Messages.Add(
                    new Message()
                    {
                        Content = "test Message 1",
                        GroupDest = "General",
                        Sender = "david",
                        Timestamp = DateTime.Parse("7/25/2017 3:02PM")
                    }
                );
                this.Messages.Add(
                    new Message()
                    {
                        Content = "test Message ack 1",
                        GroupDest = "General",
                        Sender = "brendan",
                        Timestamp = DateTime.Parse("7/25/2017 3:03PM")
                    }
                );
                this.Messages.Add(
                    new Message()
                    {
                        Content = "test Message 2",
                        GroupDest = "General",
                        Sender = "david",
                        Timestamp = DateTime.Parse("7/25/2017 3:03PM")
                    }
                );
                this.Messages.Add(
                    new Message()
                    {
                        Content = "test Message ack 2",
                        GroupDest = "General",
                        Sender = "mother",
                        Timestamp = DateTime.Parse("7/25/2017 3:03PM")
                    }
                );
                this.SaveChanges();
            }
        }
        
        public MessageContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        public Message[] GetMessagesForGroup(string group)
        {
            return this.Messages.Where(p => p.GroupDest == group).ToArray();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: Replace/remove. thanks.
            var str = Environment.GetEnvironmentVariable("");
            options.UseInMemoryDatabase();
            base.OnConfiguring(options);
        }

    }
}