using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ILocation
    {
        Guid Id { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string ZipCode { get; set; }
        string Address { get; set; }
    }
}