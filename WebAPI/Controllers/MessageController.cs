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
        // POST: api/Message
        [HttpPost]
        [Route("api/Message")]
        public HttpResponseMessage Post([FromBody]Message msg)
        {
            if (msg != null)
            {
                Global.MainController.AddMessage(msg);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        // POST: api/Message
        [HttpGet]
        [Route("api/Message")]
        public Message Get()
        {
            return new Message("endpoint", "messagetext", DateTime.Now);
        }
    }
}
