using CrypticCities.Migrations;
using CrypticCities.Models;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CrypticCities
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MiniProfilerEF6.Initialize();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();
            //if (Request.IsLocal)
            //{
               
            //}
            

        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
