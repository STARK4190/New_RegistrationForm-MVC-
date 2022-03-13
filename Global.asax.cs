using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace New_RegistrationForm24Feb
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //here application level handle error
            //global Handle error show view(Shared>Error)           
             GlobalFilters.Filters.Add(new HandleErrorAttribute() /*{View="Error2" }*/ ); //if you want to change the error page uncomment this
         //   GlobalFilters.Filters.Add(new AuthorizeAttribute());


        }
    }
}
