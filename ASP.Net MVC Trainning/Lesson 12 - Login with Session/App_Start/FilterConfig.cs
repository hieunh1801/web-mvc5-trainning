﻿using System.Web;
using System.Web.Mvc;

namespace Lesson_12___Login_with_Session
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
