using System.Web.Mvc;
using System.Web.Routing;

namespace RESTfulMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Individual resource action",
                "{controller}/{id}/{action}",
                new { action = "Index" },
                new
                {
                    httpMethod = new HttpMethodConstraint("GET"), // only allow GET for custom actions
                    id = @"\d+" // id must be numeric
                }
            );

            routes.MapRoute(
                "Individual resource",
                "{controller}/{id}",
                new { action = "Index" },
                new { id = @"\d+" } // id must be numeric
            );
            
            routes.MapRoute(
                "Resource collection action",
                "{controller}/{action}",
                new { action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET") } // only allow GET for custom actions
            );

            routes.MapRoute(
                "Resource collection",
                "{controller}",
                new { action = "Index" }
            );

            routes.MapRoute(
                "Default",
                "",
                new { controller = "Home", action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET") }  // only allow GET for default
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new RestfulControllerFactory());
        }
    }
}