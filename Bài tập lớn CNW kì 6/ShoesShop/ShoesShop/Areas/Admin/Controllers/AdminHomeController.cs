﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Security;
namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/Home
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}