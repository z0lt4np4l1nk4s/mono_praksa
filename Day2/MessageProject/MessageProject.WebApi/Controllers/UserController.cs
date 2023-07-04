using MessageProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageProject.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private List<User> Users { get { return StaticData.users; } }


        // GET: api/User
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Users.Select(x => new UserView(x)));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't get all"); }
        }

        // GET: api/User/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                User user = Users.FirstOrDefault(x => x.Id == id);
                if (user == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, new UserView(user));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't get by Id"); }
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]PostUser newUser)
        {
            try
            {
                if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, "Fill all fields");
                User user = new User()
                {
                    Id = Users.Count == 0 ? 1 : Users.Max(x => x.Id) + 1,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Username = newUser.Username
                };
                user.UpdateTime = user.CreationTime = DateTime.Now;
                Users.Add(user);
                return Request.CreateResponse(HttpStatusCode.Created, new UserView(user));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't create"); }
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]PostUser user)
        {
            try
            {
                if (!ModelState.IsValid) BadRequest("Fill all fields");
                User oldUser = Users.SingleOrDefault(x => x.Id == id);
                if (oldUser == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                oldUser.Username = user.Username;
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.UpdateTime = DateTime.Now;
                return Request.CreateResponse(HttpStatusCode.OK, new UserView(oldUser));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't update"); }
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                User user = Users.SingleOrDefault(x => x.Id == id);
                if (user == null) return Request.CreateResponse(HttpStatusCode.NotFound);

                StaticData.messages.RemoveAll(x => x.SenderId == id);

                Users.Remove(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't delete"); }
        }
    }
}
