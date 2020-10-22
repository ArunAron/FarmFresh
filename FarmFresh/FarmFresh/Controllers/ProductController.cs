using DataAccess.Model;
using DataAccess.SearchModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DA;
using DataAccess;

namespace FarmFresh.Controllers
{
    public class ProductController : Controller
    {
        DA_Product da = new DA_Product();
        CommonClass cs = new CommonClass();

        // GET: Product
        public ActionResult ProductList()
        {
            return View();
        }

        public ActionResult ProductListPartial(string getpassdata)
        {
            List<Product> list = new List<Product>();
            if (!string.IsNullOrEmpty(getpassdata))
            {
                var serializeData = JsonConvert.DeserializeObject<SM_Search>(getpassdata);
                if (serializeData.SerachType == "onsale")
                {
                    list = da.GetProducts_ByOnSale(serializeData);
                    ViewBag.TotalPagePartial = cs.TotalPage(da.Count_GetProducts_ByOnSale(serializeData));
                }
                else if (serializeData.SerachType == "new")
                {
                    list = da.GetProducts_ByNew(serializeData);
                    ViewBag.TotalPagePartial = cs.TotalPage(da.Count_GetProducts_ByNew(serializeData));
                }
                else if (serializeData.SerachType == "shopbystore")
                {
                    list = da.GetProducts_ByShopByStore(serializeData);
                    ViewBag.TotalPagePartial = cs.TotalPage(da.Count_GetProducts_ByShopByStore(serializeData));
                }
                else
                {
                    list = da.GetProducts_ByProductType(serializeData);
                    ViewBag.TotalPagePartial = cs.TotalPage(da.Count_GetProducts_ByProductType(serializeData));
                }
                ViewBag.CurrentPagePartial = serializeData.CurrentPage - 1;
            }
            return PartialView("ProductListPartial", list);
        }

        public ActionResult ProductDetail(string GUID)
        {
            Product modal = da.GetProductByGUID(GUID);
            return PartialView("ProductDetail", modal);
        }

        public ActionResult SearchMain(string getpassdata)
        {
            List<Product> list = new List<Product>();
            if (!string.IsNullOrEmpty(getpassdata))
            {
                list = da.GetProducts_ByAllPossibleSearch(getpassdata);
            }
            return PartialView("SearchMain", list);
        }


    }
}