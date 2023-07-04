using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class StaticData
    {
        public static readonly List<User> users = new List<User>();
        public static readonly List<Message> messages = new List<Message>();
    }
}