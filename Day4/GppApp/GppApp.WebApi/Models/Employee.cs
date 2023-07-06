using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public class Employee : User
    {
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }
    }
}