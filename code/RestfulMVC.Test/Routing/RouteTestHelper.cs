using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace RESTfulMVC.Test.Routing
{
    public static class RouteTestHelper
    {
        public static void Map(this RouteCollection routes, string httpMethod, string url, object expectations)
        {
            var routeData = RetrieveRouteData(routes, httpMethod, url);
            Assert.IsNotNull(routeData, "Should have found the route");

            foreach (PropertyValue property in GetProperties(expectations))
            {
                Assert.IsTrue(string.Equals(property.Value.ToString(), routeData.Values[property.Name].ToString(), StringComparison.OrdinalIgnoreCase)
                              , string.Format("Expected '{0}', not '{1}' for '{2}'.", property.Value, routeData.Values[property.Name], property.Name));
            }
        }

        public static void DoNotMap(this RouteCollection routes, string httpMethod, string url)
        {
            var routeData = RetrieveRouteData(routes, httpMethod, url);
            Assert.IsNull(routeData, "Should not find a route");
        }

        private static RouteData RetrieveRouteData(RouteCollection routes, string httpMethod, string url)
        {
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            httpContext.Setup(c => c.Request.HttpMethod).Returns(httpMethod);

            return routes.GetRouteData(httpContext.Object);
        }

        private static IEnumerable<PropertyValue> GetProperties(object o)
        {
            return from prop in TypeDescriptor.GetProperties(o).Cast<PropertyDescriptor>()
                   let val = prop.GetValue(o)
                   where val != null
                   select new PropertyValue { Name = prop.Name, Value = val };
        }


        private sealed class PropertyValue
        {
            public string Name
            {
                get;
                set;
            }

            public object Value
            {
                get;
                set;
            }
        }
    }
}