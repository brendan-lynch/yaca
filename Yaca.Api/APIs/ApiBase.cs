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

    public class ApiResponse : ApiCommand
    {
        public ApiResponse(string respondingToCommand) : base(respondingToCommand) {}
        public string Result { get; set; }
        public string Message { get; set; }
    }
 
}