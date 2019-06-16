using System.Web.Mvc;
using System.Web.Routing;
using Lesson_12___Login_with_Session.Models;

namespace Lesson_12___Login_with_Session.Security
{
    public class MyAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SimpleSessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
            }
            else
            {
                AccountModel accountModel = new AccountModel();
                CustomPrincipal customPrincipal = new CustomPrincipal(accountModel.find(SimpleSessionPersister.Username));
                if (!customPrincipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
                }
            }
        }
    }
}