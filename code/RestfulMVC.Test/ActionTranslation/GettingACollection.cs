using System;
using System.Web.Routing;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.ActionTranslation
{
    [TestFixture]
    public class GettingACollection : Test
    {
        private ActionTranslator translator;
        private string actionName;
        private RouteValueDictionary routeValues;

        protected override void Given()
        {
            routeValues = new RouteValueDictionary { { "action", "Index" } };
            translator = new ActionTranslator();
        }

        protected override void When()
        {
            actionName = translator.DetermineActionName("GET", routeValues);
        }

        [Then]
        public void ActionNameBecomesIndex()
        {
            actionName.IsEqualTo("Index");
        }
    }
}