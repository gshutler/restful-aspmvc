using System.Web.Mvc;

namespace RESTfulMVC.Core
{
    public class ActionInvoker : ControllerActionInvoker
    {
        private readonly IActionTranslator actionTranslator;

        public ActionInvoker(IActionTranslator actionTranslator)
        {
            this.actionTranslator = actionTranslator;
        }

        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            var request = controllerContext.HttpContext.Request;
            var routeValues = controllerContext.RouteData.Values;

            var translatedActionName = actionTranslator.DetermineActionName(request.HttpMethod, routeValues);

            return base.InvokeAction(controllerContext, translatedActionName);
        }
    }
}