using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwitchForum.ErrorHandler
{
    public class ArgumentExceptionHandleFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var model = new HandleErrorInfo(filterContext.Exception, filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString());
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/CustomError.cshtml",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            };
            filterContext.ExceptionHandled = true;
        }
    }
}