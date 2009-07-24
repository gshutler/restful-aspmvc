using System;
using NUnit.Framework;
using RESTfulMVC.Core;

namespace RESTfulMVC.Test.FormGeneration
{
    [TestFixture]
    public class DeleteAResource : Test
    {
        private User user;
        private string formHtml;

        protected override void Given()
        {
            user = new User { Id = 9 };
        }

        protected override void When()
        {
            formHtml = RestfulForm.Destroy(user);
        }

        [Then]
        public void CreatesTheExpectedFormTagWithAPostOverload()
        {
            formHtml.IsEqualTo("<form action=\"/Users/9!DELETE\" method=\"POST\">");
        }
    }
}