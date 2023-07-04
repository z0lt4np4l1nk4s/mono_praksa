using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class PostMessage
    {
        public int SenderId { get; set; }
        public string Text { get; set; }
    }
}