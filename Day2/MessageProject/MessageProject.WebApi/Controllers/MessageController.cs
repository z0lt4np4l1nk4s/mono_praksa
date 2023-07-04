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
                return Ok(Messages.Select(x => new MessageView(x)));
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
                return Ok(new MessageView(message));
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
                return Ok(new MessageView(message));
            }
            catch { return InternalServerError(); }
        }

        // POST: api/Message
        public IHttpActionResult Post([FromBody] PostMessage postMessage)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Fill all fields");
                if (!Users.Any(x => x.Id == postMessage.SenderId)) return BadRequest();
                Message message = new Message()
                {
                    Id = Messages.Count == 0 ? 1 : Messages.Max(x => x.Id) + 1,
                    Text = postMessage.Text,
                    SenderId = postMessage.SenderId
                };
                message.CreationTime = message.UpdateTime = DateTime.Now;
                Messages.Add(message);
                return Created("", new MessageView(message));
            }
            catch { return InternalServerError(); }
        }

        // PUT: api/Message/5
        public IHttpActionResult Put(int id, [FromBody]PutMessage message)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Fill all fields");
                Message oldMessage = Messages.SingleOrDefault(x => x.Id == id);
                if (oldMessage == null) return NotFound();
                oldMessage.Text = message.Text;
                oldMessage.UpdateTime = DateTime.Now;
                return Ok(new MessageView(oldMessage));
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
