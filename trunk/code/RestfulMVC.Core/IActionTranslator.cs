using System.Collections.Specialized;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public interface IActionTranslator
    {
        string DetermineActionName(string httpVerb, NameValueCollection form, RouteValueDictionary routeValues);
    }
}