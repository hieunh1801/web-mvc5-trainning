using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Models.Functions;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        // GET: Admin/AdminAccount
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account account)
        {

            Session["username"] = account.userName;
            Session["password"] = account.password;
            return RedirectToAction("Index", "AdminHome");
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session["username"] = "";
            Session["password"] = "";
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1)); Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            this.Response.Clear();
            
            return RedirectToAction("Login");
        }
    }
}