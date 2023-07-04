using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class PutMessage
    {
        [Required]
        public string Text { get; set; }
    }
}