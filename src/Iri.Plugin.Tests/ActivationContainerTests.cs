using Iri.IoC;
using Iri.Plugin.Tests.Types;
using Xunit;

namespace Iri.Plugin.Tests
{
    public class ActivationContainerTests
    {
        [Fact]
        public void CanUseInjectionContainer()
        {
            var mapGenerator = new MapGenerator(new CookieJar());
            mapGenerator.LoadPlugins(); // load plugins
            var map = mapGenerator.Run();
            Assert.Equal(map, new[] { 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0 });
        }
    }
}
