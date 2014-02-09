using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GamesEventManager.Models;
using ServiceStack.OrmLite;

namespace GamesEventManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static OrmLiteConnectionFactory DbFactory;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DbFactory =
              new OrmLiteConnectionFactory(
                  ConfigurationManager.ConnectionStrings["HighlandGames"].ConnectionString,
                  SqlServerDialect.Provider);

            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                const bool overwrite = false;
                db.CreateTables(overwrite, typeof(Event));
            }
        }
    }
}
