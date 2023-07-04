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
        private readonly List<Message> messages = new List<Message>();

        // GET: api/Message
        public IEnumerable<Message> Get()
        {
            return messages;
        }

        // GET: api/Message/5
        public Message Get(string id)
        {
            Message message = messages.SingleOrDefault(x => x.Id == id);
            return message;
        }

        // POST: api/Message
        public void Post([FromBody]Message message)
        {
            message.Id = Guid.NewGuid().ToString();
            message.CreationTime = message.UpdateTime = DateTime.Now;
            messages.Add(message);
        }

        // PUT: api/Message/5
        public void Put(string id, [FromBody]Message message)
        {
            Message oldMessage = messages.SingleOrDefault(x => x.Id == id);
            if (oldMessage == null) return;
            oldMessage.Text = message.Text;
            oldMessage.UpdateTime = DateTime.Now;
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            Message oldMessage = messages.SingleOrDefault(x => x.Id == id);
            if(oldMessage == null) return;
            messages.Remove(oldMessage);
        }
    }
}
