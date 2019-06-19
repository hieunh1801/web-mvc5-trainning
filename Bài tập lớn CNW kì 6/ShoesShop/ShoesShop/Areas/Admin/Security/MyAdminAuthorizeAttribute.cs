using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ShoesShop.Areas.Admin.Security;
using ShoesShop.Areas.Admin.Models.Entities;
using ShoesShop.Areas.Admin.Models.Functions;
namespace ShoesShop.Areas.Admin.Security
{
    public class MyAdminAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Step 1: Check if account not exist in session
            var username = HttpContext.Current.Session["username"];
            var password = HttpContext.Current.Session["password"];
            if (username==null || password==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AdminAccount", action = "Login" }));
            }
            else
            {
                // Step 2: If exist username and password => Check in database   
                AccountFunction accountFunction = new AccountFunction();
                Account account = accountFunction.getAccountByUserNameAndPassword(username.ToString(), password.ToString());
                if (account == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AdminError", action = "Index" }));
                } else if(account != null)
                {
                    CustomAdminPrincipal customAdminPrincipal = new CustomAdminPrincipal(account);

                    // Step 3: If account pass filter => redirect to Admin Page
                    if (!customAdminPrincipal.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AdminError", action = "Index" }));
                    }
                }
            }
        }
    }
}