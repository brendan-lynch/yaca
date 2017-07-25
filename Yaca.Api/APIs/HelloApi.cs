using System;
using System.Collections.Generic;

namespace Yaca.Api
{
    public class HelloCommand : ApiCommand
    {
        public string UserId { get; set; }
    }

    public class HelloResponse : ApiResponse
    {
        public HelloResponse(string respondingToCommand) : base(respondingToCommand) {}
        public IEnumerable<Group> Groups { get; set; }
    }
}