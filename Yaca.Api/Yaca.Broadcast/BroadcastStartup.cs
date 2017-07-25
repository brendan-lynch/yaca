using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaca.Api.Broadcast
{
    public class BroadcastStartup
    {
        public BroadcastStartup()
        {
        }

        public void BroadcastMessage(Models.Message msg)
        {
            // Do a lookup for the groups
            var ctx = new Models.GroupContext();
            var users = ctx.Groups.Where(p => p.Name == msg.GroupDest).Select(p => p.User);

            foreach(var user in users)
            {
                BroadcastReceiver.BroadcastToUser(user, msg); 
            }
        }

        public string[] GetGroups(string user)
        {
            var ctx = new Models.GroupContext();
            return ctx.GetGroupsForUser(user).Select(p => p.Name).ToArray();
        }
    }
}