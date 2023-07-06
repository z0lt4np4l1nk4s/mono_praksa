using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public class Customer : User
    {
        public DateTime RegisterDate { get; set; }
    }
}