using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommonClass
    {
        public static int PageSize = 8;
        
        public static string NulltoEmptyString(string data)
        {
            if (string.IsNullOrEmpty(data))
                data = "";
            return data;
        }

        public int TotalPage(int totalCount)
        {
            int Total = 0;
            Total = totalCount;
            float Pages_Count = Total / PageSize;
            float pages_count_mod = Total % PageSize;
            if (pages_count_mod != 0)
            {
                Pages_Count++;

            }
            Total = Convert.ToInt32(Pages_Count);
            return Total;
        }

        public List<string> PackingType()
        {
            List<string> lst = new List<string>();
            lst.Add("Packet");
            lst.Add("Box");
            lst.Add("Bag");
            return lst;
        }
        
        public List<ProductType> ProductTypeList()
        {
            List<ProductType> lst = new List<ProductType>();
            lst.Add(new ProductType { Value = "fruitandveg", ProductTypeName = "Fruit & veg" });
            lst.Add(new ProductType { Value = "meatandseafood", ProductTypeName = "Meat & Seafood" });
            lst.Add(new ProductType { Value = "dairyandchilled", ProductTypeName = "Dairy and Chilled" });
            lst.Add(new ProductType { Value = "bakery", ProductTypeName = "Bakery" });
            lst.Add(new ProductType { Value = "beverages", ProductTypeName = "Beverages" });
            return lst;
        }

        public static List<ProductType> ProductTypeListStatic()
        {
            List<ProductType> lst = new List<ProductType>();
            lst.Add(new ProductType { Value = "fruitandveg", ProductTypeName = "Fruit & veg" });
            lst.Add(new ProductType { Value = "meatandseafood", ProductTypeName = "Meat & Seafood" });
            lst.Add(new ProductType { Value = "dairyandchilled", ProductTypeName = "Dairy and Chilled" });
            lst.Add(new ProductType { Value = "bakery", ProductTypeName = "Bakery" });
            lst.Add(new ProductType { Value = "beverages", ProductTypeName = "Beverages" });
            return lst;
        }
    }
}
