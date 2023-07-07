using GppApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class SellingPoint : ISellingPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime CreationTime { get; set; }
    }
}