using System.Web.Mvc;
using System.Web.Routing;
using RESTfulMVC.Core;

namespace PostOverloading
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // register the routes of RESTful MVC
            Routes.Register(routes);

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
            // Set the controller factory to the RESTful MVC one
            // I've used poor-man's dependency injection I would recommend 
            // using an IOC container in production
            ControllerBuilder.Current.SetControllerFactory(
                new ControllerFactory(new ActionInvoker(new ActionTranslator())));
        }
    }
}