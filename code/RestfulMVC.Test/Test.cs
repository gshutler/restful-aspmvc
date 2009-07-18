using NUnit.Framework;

namespace RESTfulMVC.Test
{
    public abstract class Test
    {
        protected abstract void Given();
        protected abstract void When();

        [TestFixtureSetUp]
        public void Setup()
        {
            Given();
            When();
        }
    }
}