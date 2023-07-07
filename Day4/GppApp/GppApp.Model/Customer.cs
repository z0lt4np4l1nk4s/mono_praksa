using GppApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class Customer : User, ICustomer
    {
        public DateTime RegisterDate { get; set; }
    }
}