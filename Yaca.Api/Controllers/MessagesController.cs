using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yaca.Api;

namespace Yaca.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        [HttpPost("hello")]
        public ApiResponse Hello([FromBody] HelloCommand hello)
        {
            Console.WriteLine(hello.Command);
            Console.WriteLine(hello.UserId);

            // Query all group IDs:
            var broadcast = new Broadcast.BroadcastStartup();
            
            string[] groups = broadcast.GetGroups(hello.UserId);

            // With all groups, query messages:
            var t = new Messages.MessagesStartup();
            
            var resp = new HelloResponse(hello.Command);
            var gs = new List<Group>();
            resp.Result = "OK";
            resp.Message = hello.UserId;
            
            foreach(var group in groups)
            {
                gs.Add( new Group() { Name = group, History = t.GetMessagesForGroup(group) });
            }

            resp.Groups = gs;
            return resp;
        }

        [HttpPost("send")]
        public ApiResponse Send([FromBody] Models.Message msg)
        {
            var t = new Messages.MessagesStartup();
            t.SendMessage(msg);

            return new ApiResponse("send") { Message = "Sent", Result = "OK" };
        }

        [HttpGet("receive/{user}/{group}")]
        public MessageResponse Receive(string user, string group)
        {
            MessageResponse resp = null;
            ManualResetEvent mre = new ManualResetEvent(false);
            
            Broadcast.BroadcastReceiver.SetBroadcastCallback(user, group, (Models.Message msg) => {             
                resp = new MessageResponse("receive") 
                {
                    Result = "OK",
                    Message = null,
                    Data = new Models.Message[] { msg } };
                mre.Set();
            });

            mre.WaitOne();

            return resp;
        }

        // // GET api/values
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
