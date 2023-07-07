using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class LocationView
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }

        public LocationView() { }

        public LocationView(Location location)
        {
            Country = location.Country;
            City = location.City;
            ZipCode = location.ZipCode;
            Address = location.Address;
        }
    }
}