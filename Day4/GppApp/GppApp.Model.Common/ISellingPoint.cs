using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ISellingPoint
    {
        Guid Id { get; set; }
        string Name { get; set; }
        Guid LocationId { get; set; }
        DateTime CreationTime { get; set; }
    }
}