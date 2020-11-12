using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class OKController : ApiController
    {
        // GET: api/OK
        public IEnumerable<string> Get()
        {
            return new string[] { "OK" };
        }

        // GET: api/OK/5
        public string Get(int id)
        {
            return "OK";
        }

        // POST: api/OK
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OK/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OK/5
        public void Delete(int id)
        {
        }
    }
}
