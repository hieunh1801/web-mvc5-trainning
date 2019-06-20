using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Models.Functions;
using ShoesShop.Areas.Admin.Models.Entities;
namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: Admin/AdminProduct
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult List()
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            List<Sho> listShoes = shoesFunction.GetAll();
            return View(listShoes);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Sho shoes)
        {
            return View();
        }

        public ActionResult Search(string searchValue)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            List<Sho> listShoes = shoesFunction.Search(searchValue);
            var result = listShoes.Select(item => new { name = item.name});
            
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
    }
}