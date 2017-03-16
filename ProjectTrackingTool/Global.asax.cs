using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectTrackingTool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //model first approach
            Database.SetInitializer<ProjectContext>(new ProjectContextInitializer());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            CultureInfo culture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = culture;

            Thread.CurrentThread.CurrentUICulture = culture;

        }
    }
}
