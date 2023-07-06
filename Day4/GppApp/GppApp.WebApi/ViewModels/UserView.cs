using GppApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.ViewModels
{
    public abstract class UserView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public LocationView Location { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserView() { }

        public UserView(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Location = new LocationView(user.Location);
            DateOfBirth = user.DateOfBirth;
        }
    }
}