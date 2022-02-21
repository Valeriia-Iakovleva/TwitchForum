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
            if (!filterContext.ExceptionHandled &&
                filterContext.Exception.GetType() == typeof(ArgumentException))
            {
                filterContext.Result = new ContentResult() { Content = "You failed something!" };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}