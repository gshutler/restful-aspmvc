using System;
using System.Collections.Specialized;
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
        private NameValueCollection form;

        protected override void Given()
        {
            routeValues = new RouteValueDictionary { { "action", "Index" } };
            form = new NameValueCollection();

            translator = new ActionTranslator();
        }

        protected override void When()
        {
            actionName = translator.DetermineActionName("POST", form, routeValues);
        }

        [Then]
        public void ActionNameBecomesCreate()
        {
            actionName.IsEqualTo("Create");
        }
    }
}