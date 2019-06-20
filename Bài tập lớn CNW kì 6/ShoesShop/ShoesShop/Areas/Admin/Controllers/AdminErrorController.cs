using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminErrorController : Controller
    {
        // GET: Admin/AdminError
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}