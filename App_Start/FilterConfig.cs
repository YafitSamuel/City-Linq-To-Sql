﻿using System.Web;
using System.Web.Mvc;

namespace City_Mvc_Web_Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
