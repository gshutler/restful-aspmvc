using System;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.FormGeneration
{
    [TestFixture]
    public class PutToAResource : Test
    {
        private User user;
        private string formHtml;

        protected override void Given()
        {
            user = new User { Id = 12 };
        }

        protected override void When()
        {
            formHtml = RestfulForm.Update(user);
        }

        [Then]
        public void CreatesTheExpectedFormTagWithAPostOverload()
        {
            formHtml.IsEqualTo("<form action=\"/Users/12\" method=\"POST\">" +
                "<input type=\"hidden\" name=\"_method\" value=\"PUT\" />");
        }
    }
}