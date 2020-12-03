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
        // GET: api/Message/{id:chat_id}
        [HttpGet]
        [Route("api/Message/{chatID:long}")]
        public List<Message> Get([FromUri]long chatID)
        {
            Chat chat = Global.MainController.Chats.Find(x => x.ChatID == chatID);
            if(chat != null)
            {
                return chat.Messages;
            }
            return null;
        }

        // POST: api/Message/chatID
        [HttpPost]
        [Route("api/Message/{chatID:long}")]
        public HttpResponseMessage Post([FromUri] long chatID,[FromBody]Message msg)
        {
            if( msg != null)
            {
                Global.MainController.AddMessage(chatID, msg);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        //// PUT: api/Message/5
        //public void Put(int id, [FromBody]Message msg)
        //{
        //}

        //// DELETE: api/Message/5
        //public HttpResponseMessage Delete(int id)
        //{
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
    }
}
