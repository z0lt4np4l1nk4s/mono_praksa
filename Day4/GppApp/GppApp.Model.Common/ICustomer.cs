using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ICustomer : IUser
    {
        DateTime RegisterDate { get; set; }
    }
}