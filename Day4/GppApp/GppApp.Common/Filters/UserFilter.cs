using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Common.Filters
{
    public class UserFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
