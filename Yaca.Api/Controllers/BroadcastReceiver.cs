using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yaca.Api.Models;

namespace Yaca.Api.Broadcast
{
    public delegate void MessageBroadcast(Models.Message msg);

    public static class BroadcastReceiver
    {
        public static Dictionary<string, MessageBroadcast> EventBroadcast = new Dictionary<string, MessageBroadcast>();

        public static void BroadcastToUser(string user, Models.Message msg)
        {
            MessageBroadcast cb;
            var key = BroadcastReceiver.getKey(user, msg.GroupDest);

            if (BroadcastReceiver.EventBroadcast.TryGetValue(key, out cb))
            {
                cb(msg);
            }
        }

        public static void SetBroadcastCallback(string user, string group, MessageBroadcast bcb)
        {
            string key = BroadcastReceiver.getKey(user, group);

            if (BroadcastReceiver.EventBroadcast.ContainsKey(key))
            {
                BroadcastReceiver.EventBroadcast[key] = bcb;
            }
            else
            {
                BroadcastReceiver.EventBroadcast.Add(key, bcb);
            }
        }

        private static string getKey(string user, string group)
        {
            string key = string.Format("{0}*:*{1}", user, group);

            return key;
        }
    }
}