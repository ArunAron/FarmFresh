using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductType { get; set; }
        public string PackingType { get; set; }
        public bool OnSale { get; set; }
        public bool ShopByStore { get; set; }
        public string CreatedDate { get; set; }
        public int Status { get; set; }

    }
}
