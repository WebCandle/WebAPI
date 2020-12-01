using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Message/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Message/chatID
        [HttpPost]
        [Route("api/Message/{chatID:long}")]
        public void Post([FromUri] long chatID,[FromBody]string msg)
        {
            Chat chat = Global.MainController.Chats.Find(x => x.ChatID == chatID);
            if (chat != null)
            {
                //chat.AddMessage(msg);
            }
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
