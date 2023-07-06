using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public class PutEmployee : PutUser
    {
        public string Department { get; set; }
    }
}