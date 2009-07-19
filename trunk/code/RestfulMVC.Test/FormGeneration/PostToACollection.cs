using System;
using System.Web.Routing;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.FormGeneration
{
    [TestFixture]
    public class PostToACollection : Test
    {
        private string formHtml;

        protected override void Given()
        {
            Routes.Register(RouteTable.Routes);
        }

        protected override void When()
        {
            formHtml = RestfulForm.Create<User>();
        }

        [Then]
        public void CreatesTheExpectedFormTag()
        {
            formHtml.IsEqualTo("<form action=\"/Users/\" method=\"POST\">");
        }
    }
}