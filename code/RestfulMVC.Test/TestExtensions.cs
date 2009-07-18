using NUnit.Framework;

namespace RESTfulMVC.Test
{
    public static class TestExtensions
    {
        public static void IsEqualTo<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void IsTrue(this bool value)
        {
            Assert.IsTrue(value);
        }

        public static void IsFalse(this bool value)
        {
            Assert.IsFalse(value);
        }
    }
}