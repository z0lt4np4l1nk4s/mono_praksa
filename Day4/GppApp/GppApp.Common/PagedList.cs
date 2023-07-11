using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Common
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; } = 1;
        public int LastPage { get; set; } = 1;
        public int ItemCount { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public int ListSize { get => Data.Count; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
