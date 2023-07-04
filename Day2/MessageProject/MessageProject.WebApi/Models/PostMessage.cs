using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class PostMessage
    {
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}