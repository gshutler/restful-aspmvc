using System;
using System.Web.Routing;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.ActionTranslation
{
    [TestFixture]
    public class PostingToACollection : Test
    {
        private RouteValueDictionary routeValues;
        private ActionTranslator translator;
        private string actionName;

        protected override void Given()
        {
            routeValues = new RouteValueDictionary { { "action", "Index" } };
            translator = new ActionTranslator();
        }

        protected override void When()
        {
            actionName = translator.DetermineActionName("POST", routeValues);
        }

        [Then]
        public void ActionNameBecomesCreate()
        {
            actionName.IsEqualTo("Create");
        }
    }
}