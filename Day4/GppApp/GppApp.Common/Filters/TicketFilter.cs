using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Common.Filters
{
    public class TicketFilter
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public List<Guid> ZoneTypes { get; set; }
        public List<Guid> TicketTypes { get; set; }
    }
}
