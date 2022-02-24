using System.Web;
using System.Web.Mvc;

namespace New_RegistrationForm24Feb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
