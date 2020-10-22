using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SearchModel
{
    public class SM_Search
    {
        public string SerachType { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
