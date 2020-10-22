using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using DataAccess.DA;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using DataAccess.Model;

namespace FarmFresh.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
       
        public ActionResult Pagination(int Page, int Count)
        {
            ViewBag.Page = Page;
            ViewBag.Count = Count;
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetProductName(string Prefix)
        {
            //Note : you can bind same list from database  
            List<Product> ObjList = new List<Product>();
            DA_Product daMT = new DA_Product();
            ObjList = daMT.GetAllProducts();
            //Searching records from list using LINQ query  
            var CityList = (from N in ObjList
                            where N.ProductName.ToLower().Contains(Prefix.ToLower())
                            select new { N.ProductName, N.ID });
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }

        
    }
}