using System;
using System.Collections.Generic;

namespace Yaca.Api
{

    public class MessageResponse : ApiResponse
    {
        public MessageResponse(string respondingToCommand) : base(respondingToCommand) {}
        public IEnumerable<Models.Message> Data { get; set; }
    }
}