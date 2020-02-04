using Iri.IoC.Tests.Types;
using Xunit;

namespace Iri.IoC.Tests
{
    public class CookieJarFactoryTests
    {
        private CookieJar _testJar = new CookieJar();

        [Fact]
        public void CanRegisterInstances()
        {
            // register factory
            _testJar.RegisterFactory<IUselessThing, UselessCookie>();
            // attempt to create instance
            var cookie = _testJar.Create<IUselessThing>();
            var uselessRes = cookie.DoSomethingUseless();
            Assert.Equal(nameof(UselessCookie), uselessRes);
        }
    }
}