using System.Web.Mvc;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public static class Routes
    {
        public static void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "Restful resource view",
                "{controller}/{id}/{action}",
                new { action = "Index" },
                new
                {
                    httpMethod = new HttpMethodConstraint("GET"), // only allow GET for custom actions
                    id = @"\d+" // id must be numeric
                }
            );

            routes.MapRoute(
                "Restful resource post overload",
                "{controller}/{id}!{methodOverload}",
                new { action = "Index" },
                new
                {
                    httpMethod = new HttpMethodConstraint("POST"),
                    id = @"\d+", // id must be numeric
                    methodOverload = @"PUT|DELETE"
                }
            );

            routes.MapRoute(
                "Restful resource",
                "{controller}/{id}",
                new { action = "Index" },
                new
                {
                    httpMethod = new HttpMethodConstraint("GET", "PUT", "DELETE"),
                    id = @"\d+" // id must be numeric
                } 
            );

            routes.MapRoute(
                "Restful collection view",
                "{controller}/{action}",
                new { action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET") } // only allow GET for custom actions
            );

            routes.MapRoute(
                "Restful collection",
                "{controller}",
                new { action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET", "POST") }
            );
        }
    }
}