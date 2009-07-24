using System;
using System.Web.Routing;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.ActionTranslation
{
    [TestFixture]
    public class PuttingAResource : Test
    {
        private ActionTranslator translator;
        private string actionName;
        private RouteValueDictionary routeValues;

        protected override void Given()
        {
            routeValues = new RouteValueDictionary { { "action", "Index" }, { "id", "5" } };
            translator = new ActionTranslator();
        }

        protected override void When()
        {
            actionName = translator.DetermineActionName("PUT", routeValues);
        }

        [Then]
        public void ActionNameBecomesUpdate()
        {
            actionName.IsEqualTo("Update");
        }
    }
}