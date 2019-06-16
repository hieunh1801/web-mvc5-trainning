using System.Web;
using System.Web.Mvc;

namespace Nhom21_WebsiteDatVeXeKhach
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
