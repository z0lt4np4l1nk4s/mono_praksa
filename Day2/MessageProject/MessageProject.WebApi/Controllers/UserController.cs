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
                return Request.CreateResponse(HttpStatusCode.OK, Users);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't get all"); }
        }

        // GET: api/User/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                User user = Users.FirstOrDefault(x => x.Id == id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't get by Id"); }
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                user.UpdateTime = user.CreationTime = DateTime.Now;
                Users.Add(user);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't create"); }
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]User user)
        {
            try
            {
                User oldUser = Users.SingleOrDefault(x => x.Id == id);
                oldUser.UpdateTime = DateTime.Now;
                oldUser.Username = user.Username;
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                return Request.CreateResponse(HttpStatusCode.OK, oldUser);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't update"); }
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                User user = Users.SingleOrDefault(x => x.Id == id);
                Users.Remove(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't delete"); }
        }
    }
}
