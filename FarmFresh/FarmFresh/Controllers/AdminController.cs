using DataAccess;
using DataAccess.DA;
using DataAccess.Model;
using DataAccess.SearchModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FarmFresh.Controllers
{
    public class AdminController : Controller
    {
        DA_Product da = new DA_Product();
        CommonClass cs = new CommonClass();
        // GET: Admin
        
        public ActionResult ProductListAdmin(SM_Product data)
        {
            List<ProductType> lst = cs.ProductTypeList();
            lst.Add(new ProductType { Value = "all", ProductTypeName = "All" });
            ViewBag.ProductTypeList = lst.OrderBy(a => a.ProductTypeName);
            ViewBag.PackingType = cs.PackingType();
            data.ProductType = null;
            data.TotalPage = cs.TotalPage(da.Count_GetProductsAdmin(data));
            data.TotalCount = da.Count_GetProductsAdmin(data);
            data.CurrentPage = 1;

            return View(data);
        }
        public ActionResult ProductListAdminPartial(string getpassdata)
        {
            List<Product> list = new List<Product>();
            if (!string.IsNullOrEmpty(getpassdata))
            {
                var serializeData = JsonConvert.DeserializeObject<SM_Product>(getpassdata);
                if (serializeData.ProductType == "all")
                    serializeData.ProductType = null;
                list = da.GetProductsAdmin(serializeData);
                ViewBag.CurrentPagePartial = serializeData.CurrentPage - 1;
            }
           
            return PartialView("ProductListAdminPartial",list);
        }
        public  ActionResult GetTotalPage(string getpassdata)
        {
            List<Product> list = new List<Product>();
            int TotalPage = 0;
            if (!string.IsNullOrEmpty(getpassdata))
            {
                var serializeData = JsonConvert.DeserializeObject<SM_Product>(getpassdata);
                if (serializeData.ProductType == "all")
                    serializeData.ProductType = null;
                TotalPage = cs.TotalPage(da.Count_GetProductsAdmin(serializeData));
            }
            return Json(TotalPage, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditProductForm(string GUID)
        {
            Product data = new Product();
            ViewBag.ProductTypeList = cs.ProductTypeList();
            ViewBag.PackingType = cs.PackingType();
            if (!string.IsNullOrEmpty(GUID))
            {
                data = da.GetProductByGUID(GUID);
                ViewBag.SelectedProductType = data.ProductType;
            }
            return PartialView("EditProductForm", data);
        }

        [HttpPost]
        public async Task<JsonResult> UploadProductPhoto()
        {
            string fileName = string.Empty;
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                                //Use the following properties to get file's name, size and MIMEType
                    int fileSize = file.ContentLength;
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    //To save file, use SaveAs methodC:\Projects\Ant Tech\HIMS\HIMS\HIMS\UploadData\PatientPhoto\
                    file.SaveAs(Server.MapPath("~/ProductUploadPhotos/") + fileName); //File will be saved in application root
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json(fileName);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProduct(Product data)
        {
            data.ProductType = Request.Form["ProductType"];
            data.PackingType = Request.Form["PackingType"];
            if (!string.IsNullOrEmpty(data.GUID))
            {
                data.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                bool updated = da.UpdateProduct(data);
                if (updated)
                {
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                data.GUID = Guid.NewGuid().ToString();
                data.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                data.Status = 1;
                bool added = da.AddProduct(data);
                if (added)
                {
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult DeleteProduct(string GUID)
        {
            bool deleted = da.DeleteProduct(GUID);
            if (deleted)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
    }
}