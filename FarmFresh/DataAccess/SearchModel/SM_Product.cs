using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SearchModel
{
    public class SM_Product
    {
        public int ProductID { get; set; }
        public string GUID { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductType { get; set; }
        public string PackingType { get; set; }
        public string OnSale { get; set; }
        public string ShopByStore { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
