using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class SellingPointController : ApiController
    {
        // GET: api/SellingPoint
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SellingPoint/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SellingPoint
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SellingPoint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SellingPoint/5
        public void Delete(int id)
        {
        }
    }
}
