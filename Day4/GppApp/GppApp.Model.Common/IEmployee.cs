using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface IEmployee : IUser
    {
        string Department { get; set; }
        DateTime JoinDate { get; set; }
    }
}