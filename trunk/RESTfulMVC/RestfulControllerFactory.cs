using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace RESTfulMVC
{
    public class RestfulControllerFactory : DefaultControllerFactory
    {
        private readonly RestfulActionInvoker actionInvoker;

        public RestfulControllerFactory()
        {
            actionInvoker = new RestfulActionInvoker();
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName) as Controller;
            controller.ActionInvoker = actionInvoker;

            return controller;
        }

        private class RestfulActionInvoker : ControllerActionInvoker
        {
            public override bool InvokeAction(ControllerContext controllerContext, string actionName)
            {
                var request = controllerContext.HttpContext.Request;
                var httpVerb = request.HttpMethod.ToUpper();
                var routeData = controllerContext.RouteData.Values;

                // apply post overload where required
                if (httpVerb == "POST" && request.Form.AllKeys.Contains("_verb"))
                {
                    httpVerb = request.Form["_verb"].ToUpper();
                }
                
                if (actionName.ToUpper() == "INDEX") // default action
                {
                    actionName = ActionNameFromVerb(httpVerb, RouteContainsId(routeData));
                }

                return base.InvokeAction(controllerContext, actionName);
            }

            private static string ActionNameFromVerb(string httpVerb, bool idProvided)
            {
                switch (httpVerb)
                {
                    case "POST":
                        return "Create";
                    case "PUT":
                        return "Update";
                    case "DELETE":
                        return "Destroy";
                    case "GET":
                        if (idProvided) return "Show";
                        return "Index";
                }

                throw new ArgumentException(httpVerb + " cannot be handled");
            }

            private static bool RouteContainsId(RouteValueDictionary routeData)
            {
                return routeData.ContainsKey("id")
                       && routeData["id"] != null
                       && !string.IsNullOrEmpty(routeData["id"].ToString());
            }
        }
    }
}