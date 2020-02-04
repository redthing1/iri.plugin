using Iri.IoC.Tests.Types;
using Xunit;

namespace Iri.IoC.Tests {
    public class CookieJarTests {
        private CookieJar _testJar = new CookieJar();

        [Fact]
        public void CanRegisterInstances() {
            var c1 = new UselessCookie();
            _testJar.Register<IUselessThing>(c1);
            var r1 = _testJar.Resolve<IUselessThing>();
            Assert.Equal(r1, c1);
        }

        [Fact]
        public void CanRegisterMultipleInstances() {
            var c1 = new UselessCookie();
            _testJar.Register<IUselessThing>(c1);
            var c2 = new UselessCookie();
            _testJar.Register<IUselessThing>(c2);
            var uselessCookies = _testJar.ResolveAll<IUselessThing>();
            Assert.Contains(c1, uselessCookies);
            Assert.Contains(c2, uselessCookies);
        }

        [Fact]
        public void ResolvesFirstRegistered() {
            var c1 = new UselessCookie();
            _testJar.Register<IUselessThing>(c1);
            var c2 = new UselessCookie();
            _testJar.Register<IUselessThing>(c2);
            var res = _testJar.Resolve<IUselessThing>();
            Assert.Equal(c1, res);
        }

        [Fact]
        public void ResolvesNewestRegistered() {
            var c1 = new UselessCookie();
            _testJar.Register<IUselessThing>(c1);
            var c2 = new UselessCookie();
            _testJar.Register<IUselessThing>(c2);
            var res = _testJar.ResolveLast<IUselessThing>();
            Assert.Equal(c2, res);
        }

        [Fact]
        public void CanRegisterTypes() {
            _testJar.RegisterType<IUselessThing>(typeof(UselessCookie));
            var uselessThingTypes = _testJar.ResolveTypes<IUselessThing>();
        }
    }
}