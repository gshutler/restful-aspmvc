using System.Collections.Specialized;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public interface IActionTranslator
    {
        string DetermineActionName(string httpMethod, NameValueCollection form, RouteValueDictionary routeValues);
    }
}