using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Models.Functions;
using ShoesShop.Areas.Admin.Models.Entities;
using ShoesShop.Areas.Admin.Security;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: Admin/AdminProduct
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View("List");
        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult List()
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            List<Sho> listShoes = shoesFunction.GetAll();
            return View(listShoes);
        }

        [HttpGet]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Insert()
        {
            CategoryFunction categoryFunction = new CategoryFunction();
            VendorFunction vendorFunction = new VendorFunction();
            ViewBag.listCategories = categoryFunction.GetAll();
            ViewBag.listVendors = vendorFunction.GetAll();

            return View("Insert");
        }

        [HttpPost]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Insert(Sho shoes, HttpPostedFileBase photo)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            if (photo != null)
            {
                string path = "/Content/Images/"+ photo.FileName ;
                photo.SaveAs(Server.MapPath("~" + path));
                shoes.defaultUrlImage = path;
            }
            if (shoesFunction.Insert(shoes))
            {
                return RedirectToAction("List", "AdminProduct");
            }
            else {
                return RedirectToAction("InsertFail", "AdminError");
            };
            
        }

        [HttpGet]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Update(int id)
        {
            CategoryFunction categoryFunction = new CategoryFunction();
            VendorFunction vendorFunction = new VendorFunction();
            ShoesFunction shoesFunction = new ShoesFunction();
            ViewBag.listCategories = categoryFunction.GetAll();
            ViewBag.listVendors = vendorFunction.GetAll();
            Sho sho = shoesFunction.GetById(id);
            return View(sho);
        }

        [HttpPost]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Update(Sho shoes, HttpPostedFileBase photo)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            if (photo != null)
            {
                string path = "/Content/Images/" + photo.FileName;
                photo.SaveAs(Server.MapPath("~" + path));
                shoes.defaultUrlImage = path;
            }
            if (shoesFunction.Update(shoes))
            {
                return RedirectToAction("List");
            } else
            {
                return RedirectToAction("InsertFail", "AdminError");
            }
            
        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Search(string searchValue)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            List<Sho> listShoes = shoesFunction.Search(searchValue);
            var result = listShoes.Select(item => new {
                item.name,
                item.description,
                item.defaultUrlImage,
                item.idCategory,
                item.idShoes,
                item.idVendor,
                item.price
                
            });
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Delete(int idShoes)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            shoesFunction.Delete(idShoes);
            var listShoes = shoesFunction.GetAll();
            var result = listShoes.Select(item => new {
                item.name,
                item.description,
                item.defaultUrlImage,
                item.idCategory,
                item.idShoes,
                item.idVendor,
                item.price

            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}