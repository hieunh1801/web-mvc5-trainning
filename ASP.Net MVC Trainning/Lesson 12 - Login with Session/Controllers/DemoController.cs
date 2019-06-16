using Lesson_12___Login_with_Session.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson_12___Login_with_Session.Controllers
{
    public class DemoController: Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [MyAuthorizeAttribute(Roles = "superadmin")]
        public ActionResult Work1()
        {
            return View("Work1");
        }

        [MyAuthorizeAttribute(Roles = "superadmin,admin")]
        public ActionResult Work2()
        {
            return View("Work2");
        }

        [MyAuthorizeAttribute(Roles = "superadmin,admin,employee")]
        public ActionResult Work3()
        {
            return View("Work3");
        }
    }
}