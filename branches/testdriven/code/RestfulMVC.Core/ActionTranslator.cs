using System;
using System.Collections.Specialized;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public class ActionTranslator : IActionTranslator
    {
        public string DetermineActionName(string httpVerb, NameValueCollection form, RouteValueDictionary routeValues)
        {
            if (ContainsAnId(routeValues)) return DetermineResourceAction(httpVerb, form, routeValues);
            return DetermineCollectionAction(httpVerb, routeValues);
        }

        private static string DetermineCollectionAction(string httpVerb, RouteValueDictionary routeValues)
        {
            if (httpVerb == "GET") return routeValues["action"].ToString();
            return "Create";
        }

        private static string DetermineResourceAction(string httpVerb, NameValueCollection form, RouteValueDictionary dictionary)
        {
            if (httpVerb == "POST") httpVerb = PostOverloadVerb(form);

            if (httpVerb == "DELETE") return "Destroy";
            if (httpVerb == "PUT") return "Update";
            if (dictionary["action"].ToString() == "Index") return "Show";
            return dictionary["action"].ToString();
        }

        private static string PostOverloadVerb(NameValueCollection form)
        {
            return form["__verb"];
        }

        private static bool ContainsAnId(RouteValueDictionary routeValues)
        {
            return routeValues.ContainsKey("id") && routeValues["id"] != null &&
                   !string.IsNullOrEmpty(routeValues["id"].ToString());
        }
    }
}