using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using System.Xml;
using WebAPI.Models;
using System.IO;
using System.Text;

namespace WebAPI.Controllers
{
    public class ChatController : ApiController
    {
        // GET: api/Chat
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chat/5
        public string Get(long id)
        {
            Chat chat = new Chat();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Chat));
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder);
            xmlSerializer.Serialize(xmlWriter, chat);
            return "OK";
        }

        // POST: api/Chat
        public void Post([FromBody]string value)
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
