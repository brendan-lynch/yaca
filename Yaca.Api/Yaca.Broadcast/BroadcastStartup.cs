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

        public void BroadcastMessage(Message msg, IEnumerable<string> recipeints)
        {
            foreach(var user in recipeints)
            {
                BroadcastReceiver.BroadcastToUser(user, msg);
            }
        }
    }

}