using System;
using System.Collections.Specialized;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public class ActionTranslator : IActionTranslator
    {
        public string DetermineActionName(string httpMethod, NameValueCollection form, RouteValueDictionary routeValues)
        {
            if (ContainsAnId(routeValues)) return DetermineResourceAction(httpMethod, form, routeValues);
            return DetermineCollectionAction(httpMethod, routeValues);
        }

        private static string DetermineCollectionAction(string httpMethod, RouteValueDictionary routeValues)
        {
            if (httpMethod == "GET") return routeValues["action"].ToString();
            return "Create";
        }

        private static string DetermineResourceAction(string httpMethod, NameValueCollection form, RouteValueDictionary dictionary)
        {
            if (httpMethod == "POST") httpMethod = form[Constants.PostOverloadInputName];

            if (httpMethod == "DELETE") return "Destroy";
            if (httpMethod == "PUT") return "Update";
            if (dictionary["action"].ToString() == "Index") return "Show";
            return dictionary["action"].ToString();
        }

        private static bool ContainsAnId(RouteValueDictionary routeValues)
        {
            return routeValues.ContainsKey("id") && routeValues["id"] != null &&
                   !string.IsNullOrEmpty(routeValues["id"].ToString());
        }
    }
}