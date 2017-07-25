using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yaca.Api.Messages
{
    public class MessagesStartup
    {
        // public static void Main(string[] argc)
        // {
        //     // from here to GetMessagse()
        // }

        public Models.Message[] GetMessagesForGroup(string group)
        {
            var ctx = new Models.MessageContext();
            return ctx.GetMessagesForGroup(group);
        }     

        public void SendMessage(Models.Message msg)
        {
            var ctx = new Models.MessageContext();
            ctx.Messages.Add(msg);
            ctx.SaveChangesAsync();

            (new Broadcast.BroadcastStartup()).BroadcastMessage(msg);
        }   
    } 
}