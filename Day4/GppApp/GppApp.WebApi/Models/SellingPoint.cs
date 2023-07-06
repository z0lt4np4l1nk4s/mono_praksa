using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public class SellingPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime CreationTime { get; set; }
    }
}