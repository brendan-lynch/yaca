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

            // Forward Call to services for "auth"
            return new HelloResponse(hello.Command) 
            {
                 Result = "OK", 
                 Message = hello.UserId, 
                 Groups = new Group[] 
                 {
                      new Group() 
                      {
                           Name = "General", 
                           History = new Message[] 
                           {
                                new Message() 
                                { 
                                    Content = "Message here", 
                                    Source = "mother", 
                                    Target = "General", 
                                    Timestamp = DateTime.Now.AddHours(-2) 
                                } 
                            }
                        }
                    }
            };
        }

        [HttpPost("send")]
        public ApiResponse Send([FromBody] Message msg)
        {
            Broadcast.BroadcastReceiver.BroadcastToUser("dab", msg);

            return new ApiResponse("send") { Message = "Sent", Result = "OK" };
        }

        [HttpGet("receive/{user}")]
        public MessageResponse Receive(string user)
        {

            MessageResponse resp = null;
            ManualResetEvent mre = new ManualResetEvent(false);
            
            Broadcast.BroadcastReceiver.SetBroadcastCallback(user, (Message msg) => {             
                resp = new MessageResponse("receive") 
                {
                    Result = "OK",
                    Message = null,
                    Data = new Message[] { msg } };
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
