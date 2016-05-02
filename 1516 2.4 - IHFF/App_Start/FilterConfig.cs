using System.Web;
using System.Web.Mvc;

namespace _1516_2._4___IHFF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
