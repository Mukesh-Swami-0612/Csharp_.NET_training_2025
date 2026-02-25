using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // ✅ ADD THIS METHOD
        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();

            // (Optional) You can log error here

            Server.ClearError();

            Response.Redirect("~/Home/Error");
        }
    }
}