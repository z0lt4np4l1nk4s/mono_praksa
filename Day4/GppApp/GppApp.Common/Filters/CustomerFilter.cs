using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Common.Filters
{
    public class CustomerFilter : UserFilter
    {
        public DateTime? RegisterDateStart { get; set; }
        public DateTime? RegisterDateEnd { get; set; }
    }
}
