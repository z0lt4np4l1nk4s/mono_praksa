using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ITicketType
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}