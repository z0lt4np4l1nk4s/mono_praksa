using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class UserView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime CreationTime { get; set; }

        public UserView(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            CreationTime = user.CreationTime;
        }
    }
}