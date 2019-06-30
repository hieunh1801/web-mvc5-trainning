using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Models.Functions;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminColorController : Controller
    {
        // GET: Admin/AdminColor
        public ActionResult Index()
        {
            return View("List");
        }
        public ActionResult List()
        {
            ColorFunction colorFunction = new ColorFunction();
            List<Color> colors = colorFunction.GetAll();
            return View(colors);
        }

        public ActionResult Search(string searchValue)
        {
            ColorFunction colorFunction = new ColorFunction();
            List<Color> listColor = colorFunction.Search(searchValue);
            var result = listColor.Select(item => new {
                item.idColor,
                item.color,
            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}