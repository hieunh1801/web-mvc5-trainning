using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson_12___Login_with_Session.Security;
using Lesson_12___Login_with_Session.Models;
using Lesson_12___Login_with_Session.ViewModels;


namespace Lesson_12___Login_with_Session.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel accountViewModel)
        {
            AccountModel accountModel = new AccountModel();
            if (string.IsNullOrEmpty(accountViewModel.Account.Username) || string.IsNullOrEmpty(accountViewModel.Account.Password) || accountModel.login(accountViewModel.Account.Username, accountViewModel.Account.Password) == null)
            {
                ViewBag.Error = "Please provide your username and password correct!!!";
                return View("Index");
            }
            SimpleSessionPersister.Username = accountViewModel.Account.Username;
            return View("Welcome");
        }

        public ActionResult Logout()
        {
            SimpleSessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }

    }
}