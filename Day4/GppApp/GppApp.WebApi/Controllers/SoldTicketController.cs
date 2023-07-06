using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class SoldTicketController : ApiController
    {
        // GET: api/SoldTicket
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SoldTicket/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SoldTicket
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SoldTicket/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SoldTicket/5
        public void Delete(int id)
        {
        }
    }
}
