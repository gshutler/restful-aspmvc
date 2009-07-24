using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public interface IActionTranslator
    {
        string DetermineActionName(string httpMethod, RouteValueDictionary routeValues);
    }
}