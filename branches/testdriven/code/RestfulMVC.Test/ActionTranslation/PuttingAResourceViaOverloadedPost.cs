using System;
using System.Collections.Specialized;
using System.Web.Routing;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.ActionTranslation
{
    [TestFixture]
    public class PuttingAResourceViaOverloadedPost : Test
    {
        private ActionTranslator translator;
        private string actionName;
        private NameValueCollection form;
        private RouteValueDictionary routeValues;

        protected override void Given()
        {
            routeValues = new RouteValueDictionary { { "action", "Index" }, { "id", "5" } };
            form = new NameValueCollection { { "__verb", "PUT" }};

            translator = new ActionTranslator();
        }

        protected override void When()
        {
            actionName = translator.DetermineActionName("POST", form, routeValues);
        }

        [Then]
        public void ActionNameBecomesUpdate()
        {
            actionName.IsEqualTo("Update");
        }
    }
}