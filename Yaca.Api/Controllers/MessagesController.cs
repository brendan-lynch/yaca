using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yaca.Api;

namespace Yaca.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {

        [HttpPost("hello")]
        public ApiResponse Hello(HelloCommand hello)
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
        public ApiResponse Send(Message msg)
        {
            return new ApiResponse("send") { Message = "Sent", Result = "OK" };
        }

        [HttpGet("receive")]
        public MessageResponse Receive()
        {
            System.Threading.Thread.Sleep(5200);

            return new MessageResponse("receive")
            {
                Result = "OK",
                Message = "Messages",
                Data = new Message[]
                {
                    new Message()
                    {
                        Source = "mother",
                        Target = "General",
                        Content = "Another message here",
                        Timestamp = DateTime.Now
                    }
                }
            };
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
