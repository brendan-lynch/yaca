using System;

namespace Yaca.Api.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string GroupDest { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
    }
}