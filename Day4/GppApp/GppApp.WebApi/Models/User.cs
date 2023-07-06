﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
    }
}