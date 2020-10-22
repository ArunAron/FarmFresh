using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DataAccess.Model;
using DataAccess.SearchModel;
using FarmFresh.DBContext;
using FarmFresh.Repo;
using PagedList;

namespace DataAccess.DA
{
    public class DA_Product
    {
        public List<Product> GetAllProducts()
        {
            List<Product> lst = new List<Product>();
            try
            {
                FarmFreshDBContext ctx = new FarmFreshDBContext();
                ProductRepository uirepo = new ProductRepository(ctx);

                IQueryable<Product> dbList = uirepo.GetDataSet().Where(a => a.Status == 1).AsQueryable();
                lst = dbList.ToList();
                ctx.Dispose();
            }
            catch (Exception e)
            {
                string error = e.Message;

            }

            return lst;
        }

        public List<Product> GetProductsAdmin(SM_Product searchData)
        {
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => (searchData.ProductType != null) ? a.ProductType == searchData.ProductType : true).ToList();
            list = list.ToPagedList(searchData.CurrentPage++, CommonClass.PageSize).ToList();
            return list;
        }
        public int Count_GetProductsAdmin(SM_Product searchData)
        {
            int Count = 0;
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => (searchData.ProductType != null) ? a.ProductType == searchData.ProductType : true).ToList();
            Count = list.Count;
            return Count;
        }


        public List<Product> GetProducts_ByProductType(SM_Search searchData)
        {
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => (searchData.SerachType != null) ? a.ProductType == searchData.SerachType : true).ToList();
            list = list.ToPagedList(searchData.CurrentPage++, CommonClass.PageSize).ToList();
            return list;
        }
        public int Count_GetProducts_ByProductType(SM_Search searchData)
        {
            int Count = 0;
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => (searchData.SerachType != null) ? a.ProductType == searchData.SerachType : true).ToList();
            Count = list.Count;
            return Count;
        }
        public List<Product> GetProducts_ByOnSale(SM_Search searchData)
        {
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => a.OnSale == true).ToList();
            list = list.ToPagedList(searchData.CurrentPage++, CommonClass.PageSize).ToList();
            return list;
        }
        public int Count_GetProducts_ByOnSale(SM_Search searchData)
        {
            int Count = 0;
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => a.OnSale == true).ToList();
            Count = list.Count;
            return Count;
        }

        public List<Product> GetProducts_ByShopByStore(SM_Search searchData)
        {
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => a.ShopByStore == true).ToList();
            list = list.ToPagedList(searchData.CurrentPage++, CommonClass.PageSize).ToList();
            return list;
        }
        public int Count_GetProducts_ByShopByStore(SM_Search searchData)
        {
            int Count = 0;
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => a.ShopByStore == true).ToList();
            Count = list.Count;
            return Count;
        }

        public List<Product> GetProducts_ByNew(SM_Search searchData)
        {
            List<Product> list = this.GetAllProducts();
            string FromDate = DateTime.Now.AddDays(-7).ToString(); 
            string ToDate = DateTime.Now.ToString();
            list = list.Where(a => DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) >= DateTime.Parse(Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd"))
                && DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) <= DateTime.Parse(Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd"))).ToList();
            list = list.ToPagedList(searchData.CurrentPage++, CommonClass.PageSize).ToList();
            return list;
        }
        public int Count_GetProducts_ByNew(SM_Search searchData)
        {
            int Count = 0;
            string FromDate = DateTime.Now.AddDays(-7).ToString();
            string ToDate = DateTime.Now.ToString();
            List<Product> list = this.GetAllProducts();
            list = list.Where(a => DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) >= DateTime.Parse(Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd"))
                && DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) <= DateTime.Parse(Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd"))).ToList();
            Count = list.Count;
            return Count;
        }

        public List<Product> GetProducts_ByAllPossibleSearch(string searchData)
        {
            searchData = searchData.ToLower().Replace(" ", "");
            List<Product> returnList = new List<Product>();
            List<Product> list = this.GetAllProducts();
            returnList.AddRange(list.Where(a => a.ProductName.ToLower().Contains(searchData)).ToList());
            //returnList.AddRange(list.Where(a => searchData.Contains(a.ProductName)).ToList());

            returnList.AddRange(list.Where(a => a.ProductType.ToLower().Contains(searchData)).ToList());
            //returnList.AddRange(list.Where(a => searchData.Contains(a.ProductType)).ToList());

            returnList.AddRange(list.Where(a => a.PackingType.ToLower().Contains(searchData)).ToList());
            //returnList.AddRange(list.Where(a => searchData.Contains(a.PackingType)).ToList());



            string onsale = "onsale";
            string shopbystore = "shopbystore";
            string newitem = "new";
            string all = "all";

            if (onsale.Contains(searchData))
            {
                returnList.AddRange(list.Where(a => a.OnSale).ToList());
            }

            if (shopbystore.Contains(searchData))
            {
                returnList.AddRange(list.Where(a => a.ShopByStore).ToList());
            }

            if (newitem.Contains(searchData))
            {
                string FromDate = DateTime.Now.AddDays(-7).ToString();
                string ToDate = DateTime.Now.ToString();
                returnList.AddRange(list.Where(a => DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) >= DateTime.Parse(Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd"))
                && DateTime.Parse(Convert.ToDateTime(a.CreatedDate).ToString("yyyy-MM-dd")) <= DateTime.Parse(Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd"))).ToList());
            }

            if (all.Contains(searchData))
            {
                returnList.AddRange(list);
            }
            return returnList;
        }



        public bool AddProduct(Product data)
        {
            bool added = false;
            FarmFreshDBContext ctx = new FarmFreshDBContext();
            ProductRepository uirepo = new ProductRepository(ctx);

            try
            {
                data.Status = 1;
                uirepo.Add(data);
                added = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                added = false;
            }
            finally
            {
                ctx.Dispose();
            }

            return added;
        }
        public bool UpdateProduct(Product data)
        {
            bool updated = false;
            FarmFreshDBContext ctx = new FarmFreshDBContext();
            ProductRepository uirepo = new ProductRepository(ctx);

            try
            {
                uirepo.update(data);
                updated = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                updated = false;
            }
            finally
            {
                ctx.Dispose();
            }
            return updated;
        }

        public Product GetProductByGUID(string GUID)
        {
            Product mdl = new Product();

            FarmFreshDBContext ctx = new FarmFreshDBContext();
            ProductRepository uirepo = new ProductRepository(ctx);
            mdl = uirepo.Get(GUID);
            return mdl;
        }
        public bool DeleteProduct(string GUID)
        {
            bool deleted = false;
            FarmFreshDBContext ctx = new FarmFreshDBContext();
            ProductRepository uirepo = new ProductRepository(ctx);


            try
            {
                Product mdl = new Product();
                mdl = GetProductByGUID(GUID);
                mdl.Status = 0;
                uirepo.update(mdl);
                deleted = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                deleted = false;
            }
            finally
            {
                ctx.Dispose();
            }

            return deleted;
        }

    }
}
