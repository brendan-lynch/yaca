using System;
using System.Collections.Generic;

namespace Yaca.Api
{
    public class Message
    {
        public string Target { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}