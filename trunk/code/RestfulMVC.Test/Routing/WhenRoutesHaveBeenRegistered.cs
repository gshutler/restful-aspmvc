using System;
using System.Web.Routing;
using NUnit.Framework;

namespace RESTfulMVC.Test.Routing
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
            routes.Map("GET", "~/Users", new { controller = "Users", action = "Index" });
        }

        [Then]
        public void IndividualResourcesHaveIndexAsTheDefaultAction()
        {
            routes.Map("GET", "~/Users/2", new { controller = "Users", action = "Index", id = "2" });
        }

        [Then]
        public void IndividualResourcesCanAcceptPutViaOverloadedPost()
        {
            routes.Map("POST", "~/Users/4!PUT", new { controller = "Users", action = "Index", methodOverload = "PUT"});
        }

        [Then]
        public void IndividualResourcesCanAcceptDeleteViaOverloadedPost()
        {
            routes.Map("POST", "~/Users/4!DELETE", new { controller = "Users", action = "Index", methodOverload = "DELETE" });
        }

        [Then]
        public void IndividualResourcesWillNotAcceptNonsenseAsAPostOverload()
        {
            routes.DoNotMap("POST", "~/Users/4!NONSENSE");
        }

        [Then]
        public void IndividualResourcesDoNotAcceptPost()
        {
            routes.DoNotMap("POST", "~/Users/2");
        }

        [Then]
        public void ResourceCollectionsCanHaveCustomViews()
        {
            routes.Map("GET", "~/Users/Recent", new { controller = "Users", action = "Recent" });
        }

        [Then]
        public void ResourceCollectionsDoNotAcceptPuts()
        {
            routes.DoNotMap("PUT", "~/Users");
        }

        [Then]
        public void ResourceCollectionsDoNotAcceptDeletes()
        {
            routes.DoNotMap("DELETE", "~/Users");
        }

        [Then]
        public void ResourceCollectionsCannotPostToCustomViews()
        {
            routes.DoNotMap("POST", "~/Users/Recent");
        }

        [Then]
        public void IndividualResourcesCanHaveCustomViews()
        {
            routes.Map("GET", "~/Users/7/Search", new { controller = "Users", action = "Search", id = "7" });
        }

        [Then]
        public void IndividualResourcesCannotPostToCustomViews()
        {
            routes.DoNotMap("POST", "~/Users/7/Search");
        }
    }
}