using System.Web;
using System.Web.Mvc;
using TwitchForum.ErrorHandler;

namespace TwitchForum
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ArgumentExceptionHandleFilter());
        }
    }
}