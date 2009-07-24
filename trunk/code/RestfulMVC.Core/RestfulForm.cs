using System;

namespace RESTfulMVC.Core
{
    public static class RestfulForm
    {
        public static string Create<TResource>()
        {
            var resourceName = typeof (TResource).Name;

            return string.Format("<form action=\"/{0}/\" method=\"POST\">", Inflector.Net.Inflector.Pluralize(resourceName));
        }

        public static string Update<TResource>(TResource resource)
        {
            return OverloadedPost(resource, "PUT");
        }

        public static string Destroy<TResource>(TResource resource)
        {
            return OverloadedPost(resource, "DELETE");
        }

        private static string OverloadedPost<TResource>(TResource resource, string httpMethod)
        {
            var resourceName = typeof(TResource).Name;

            return string.Format("<form action=\"/{0}/{1}!{2}\" method=\"POST\">", Inflector.Net.Inflector.Pluralize(resourceName), IdFrom(resource), httpMethod);
        }

        private static int IdFrom<TResource>(TResource resource)
        {
            var idProperty = typeof(TResource).GetProperty("Id");

            return (int) idProperty.GetValue(resource, null);
        }
    }
}