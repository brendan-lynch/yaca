using System;
using System.Collections.Generic;

namespace Yaca.Api
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Models.Message> History { get; set; }
    }
}