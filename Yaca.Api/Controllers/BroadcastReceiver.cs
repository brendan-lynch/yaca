using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yaca.Api.Broadcast
{
    public delegate void MessageBroadcast(Message msg);

    public static class BroadcastReceiver
    {
        public static Dictionary<string, MessageBroadcast> EventBroadcast = new Dictionary<string, MessageBroadcast>();

        public static void BroadcastToUser(string user, Message msg)
        {
            MessageBroadcast cb;

            if (BroadcastReceiver.EventBroadcast.TryGetValue(user, out cb))
            {
                cb(msg);
            }
        }

        public static void SetBroadcastCallback(string user, MessageBroadcast bcb)
        {
            if (BroadcastReceiver.EventBroadcast.ContainsKey(user))
            {
                BroadcastReceiver.EventBroadcast[user] = bcb;
            }
            else
            {
                BroadcastReceiver.EventBroadcast.Add(user, bcb);
            }
        }
    }
}