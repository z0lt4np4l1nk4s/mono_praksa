using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class ZoneTypeView
    {
        public string Name { get; set; }

        public ZoneTypeView() { }

        public ZoneTypeView(ZoneType zoneType)
        {
            Name = zoneType.Name;
        }
    }
}