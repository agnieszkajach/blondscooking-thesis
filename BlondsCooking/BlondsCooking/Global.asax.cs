using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlondsCooking.Models.Db;
using LinearRegression;

namespace BlondsCooking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Test test = new Test();
            test.TestMethod();
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var categories = context.Categories.Count();
                var recipes = context.Recipes.Count();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
