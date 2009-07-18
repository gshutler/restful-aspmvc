using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace RESTfulMVC.Core
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly ActionInvoker actionInvoker;

        public ControllerFactory(ActionInvoker actionInvoker)
        {
            this.actionInvoker = actionInvoker;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = CreateControllerInstance(requestContext, controllerName);
            
            controller.ActionInvoker = actionInvoker;

            return controller;
        }

        /// <summary>
        /// Creates a controller for the request
        /// </summary>
        /// <remarks>
        /// If you want to use an IOC container to create your controllers, this is method to override
        /// </remarks>
        protected virtual Controller CreateControllerInstance(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName) as Controller;
            if (controller == null) throw new NullReferenceException("The controller must inherit from System.Web.Mvc.Controller");
            return controller;
        }
    }
}