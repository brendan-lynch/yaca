using System;
using System.Collections.Generic;

namespace Yaca.Api
{

    public class MessageResponse : ApiResponse
    {
        public MessageResponse(string respondingToCommand) : base(respondingToCommand) {}
        public IEnumerable<Message> Data { get; set; }
    }
}