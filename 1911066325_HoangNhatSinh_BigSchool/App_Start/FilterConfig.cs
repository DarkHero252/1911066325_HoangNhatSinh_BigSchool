using System.Web;
using System.Web.Mvc;

namespace _1911066325_HoangNhatSinh_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
