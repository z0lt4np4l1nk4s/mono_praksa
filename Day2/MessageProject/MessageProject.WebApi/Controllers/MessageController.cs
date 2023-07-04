using MessageProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageProject.WebApi.Controllers
{
    public class MessageController : ApiController
    {
        private List<Message> Messages { get { return StaticData.messages; } }
        private List<User> Users { get { return StaticData.users; } }

        // GET: api/Message
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Messages);
            }
            catch { return InternalServerError(); }
        }

        // GET: api/Message/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Message message = Messages.SingleOrDefault(x => x.Id == id);
                if (message == null) return NotFound();
                return Ok(message);
            }
            catch { return InternalServerError(); }
        }

        // GET: api/Message/GetById?id=5
        [HttpGet, Route(Name = "api/[controller]/[action]")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                Message message = Messages.SingleOrDefault(x => x.Id == id);
                if (message == null) return NotFound();
                return Ok(message);
            }
            catch { return InternalServerError(); }
        }

        // POST: api/Message
        public IHttpActionResult Post([FromBody] Message message)
        {
            try
            {
                if (!Users.Any(x => x.Id == message.SenderId)) return BadRequest();
                message.Id = Messages.Count == 0 ? 1 : Messages.Max(x => x.Id) + 1;
                message.CreationTime = message.UpdateTime = DateTime.Now;
                Messages.Add(message);
                return Ok(message);
            }
            catch { return InternalServerError(); }
        }

        // PUT: api/Message/5
        public IHttpActionResult Put(int id, [FromBody]Message message)
        {
            try
            {
                Message oldMessage = Messages.SingleOrDefault(x => x.Id == id);
                if (oldMessage == null) return NotFound();
                oldMessage.Text = message.Text;
                oldMessage.UpdateTime = DateTime.Now;
                return Ok(oldMessage);
            }
            catch { return InternalServerError(); }
        }

        // DELETE: api/Message
        public IHttpActionResult Delete()
        {
            try
            {
                Messages.Clear();
                return Ok();
            }
            catch { return InternalServerError(); }
        }

        // DELETE: api/Message/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Message oldMessage = Messages.SingleOrDefault(x => x.Id == id);
                if (oldMessage == null) NotFound();
                Messages.Remove(oldMessage);
                return Ok();
            }
            catch { return InternalServerError(); }
        }
    }
}
