using GppApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class Employee : User, IEmployee
    {
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }
    }
}