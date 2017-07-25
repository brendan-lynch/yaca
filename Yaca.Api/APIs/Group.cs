using System;
using System.Collections.Generic;

namespace Yaca.Api
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Message> History { get; set; }
    }
}