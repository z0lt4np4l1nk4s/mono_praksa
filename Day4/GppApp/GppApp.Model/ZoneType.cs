using GppApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class ZoneType : IZoneType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}