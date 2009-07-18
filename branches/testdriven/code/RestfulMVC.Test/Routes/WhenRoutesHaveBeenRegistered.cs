using System;
using System.Web.Routing;
using NUnit.Framework;

namespace RESTfulMVC.Test.Routes
{
    [TestFixture]
    public class WhenRoutesHaveBeenRegistered : Test
    {
        private RouteCollection routes;

        protected override void Given()
        {
            routes = new RouteCollection();
        }

        protected override void When()
        {
            Core.Routes.Register(routes);
        }

        [Then]
        public void ResourceCollectionsHaveIndexAsTheDefaultAction()
        {
            routes.Maps("GET", "~/Users", new { controller = "Users", action = "Index" });
        }

        [Then]
        public void IndividualResourcesHaveIndexAsTheDefaultAction()
        {
            routes.Maps("GET", "~/Users/2", new { controller = "Users", action = "Index", id = "2" });
        }

        [Then]
        public void ResourceCollectionsCanHaveCustomViews()
        {
            routes.Maps("GET", "~/Users/Recent", new { controller = "Users", action = "Recent" });
        }

        [Then]
        public void ResourceCollectionsCannotPostToCustomViews()
        {
            routes.DoNotMap("POST", "~/Users/Recent");
        }

        [Then]
        public void IndividualResourcesCanHaveCustomViews()
        {
            routes.Maps("GET", "~/Users/7/Search", new { controller = "Users", action = "Search", id = "7" });
        }

        [Then]
        public void IndividualResourcesCannotPostToCustomViews()
        {
            routes.DoNotMap("POST", "~/Users/7/Search");
        }
    }
}