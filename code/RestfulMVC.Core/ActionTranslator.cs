using System;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public class ActionTranslator : IActionTranslator
    {
        public string DetermineActionName(string httpMethod, RouteValueDictionary routeValues)
        {
            if (ContainsAnId(routeValues)) return DetermineResourceAction(httpMethod, routeValues);
            return DetermineCollectionAction(httpMethod, routeValues);
        }

        private static string DetermineCollectionAction(string httpMethod, RouteValueDictionary routeValues)
        {
            if (httpMethod == "GET") return routeValues["action"].ToString();
            return "Create";
        }

        private static string DetermineResourceAction(string httpMethod, RouteValueDictionary routeValues)
        {
            if (httpMethod == "POST") httpMethod = routeValues["methodOverload"].ToString();

            if (httpMethod == "DELETE") return "Destroy";
            if (httpMethod == "PUT") return "Update";
            if (routeValues["action"].ToString() == "Index") return "Show";
            return routeValues["action"].ToString();
        }

        private static bool ContainsAnId(RouteValueDictionary routeValues)
        {
            return routeValues.ContainsKey("id") && routeValues["id"] != null &&
                   !string.IsNullOrEmpty(routeValues["id"].ToString());
        }
    }
}