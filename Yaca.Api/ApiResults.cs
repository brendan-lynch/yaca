using System;
using System.Collections.Generic;

namespace Yaca.Api
{
    public abstract class ApiCommand
    {
        public ApiCommand(string cmd)
        {
            this.Command = cmd;
        }
        public ApiCommand()
        {}

        public string Command { get; set; }
    }

    public class HelloCommand : ApiCommand
    {
        public string UserId { get; set; }
    }

    public class ApiResponse : ApiCommand
    {
        public ApiResponse(string respondingToCommand) : base(respondingToCommand) {}
        public string Result { get; set; }
        public string Message { get; set; }
    }

    public class HelloResponse : ApiResponse
    {
        public HelloResponse(string respondingToCommand) : base(respondingToCommand) {}
        public IEnumerable<Group> Groups { get; set; }
    }

    public class MessageResponse : ApiResponse
    {
        public MessageResponse(string respondingToCommand) : base(respondingToCommand) {}
        public IEnumerable<Message> Data { get; set; }
    }
    
    public class Message
    {
        public string Target { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
 
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Message> History { get; set; }
    }
}