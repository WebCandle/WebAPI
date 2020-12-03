using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ChatController : ApiController
    {
        //// GET: api/Chat
        //public Chat Get()
        //{
        //    return new Chat();
        //}

        // GET: api/Chat/5
        [HttpGet, Route("api/chat/{id:long}")]
        public Chat Get(long id)
        {
            Chat chat = Global.MainController.Chats.Find(x => x.ChatID == id);
            if (chat != null)
            {
                return chat;
            }
            else
            {
                return new Chat();
            }
        }

        // POST: api/Chat
        public void Post([FromBody]Chat chat)
        {

        }

        // PUT: api/Chat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chat/5
        public void Delete(int id)
        {
        }
    }
}
