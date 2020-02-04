using Iri.Plugin.Tests.Types;
using Iri.Plugin.Types;
using Xunit;

namespace Iri.Plugin.Tests
{
    public class PluginLoaderTests
    {
        private readonly PluginLoader<IPlugin> _loader = new PluginLoader<IPlugin>();

        [Fact]
        public void CanLoadInstancePlugin()
        {
            var cookiePluginInstance = new CookiePlugin();
            _loader.Load(cookiePluginInstance);
        }

        [Fact]
        public void CanLoadTypePluginGeneric()
        {
            _loader.Load<CookiePlugin>();
        }

        [Fact]
        public void CanLoadTypePluginType()
        {
            _loader.Load(typeof(CookiePlugin));
        }

        [Fact]
        public void PluginsAreLoaded()
        {
            var multiplier1 = new MultiplyingPlugin(1);
            var multiplier2 = new MultiplyingPlugin(2);
            _loader.LoadMany(multiplier1, multiplier2);
            Assert.Equal(2, _loader.PluginCount);
            // run all plugins
            int sum = 0;
            foreach (var plugin in _loader.Plugins)
            {
                var multiplier = (MultiplyingPlugin)plugin;
                sum += multiplier.DoFoo(1, 1);
            }
            Assert.Equal(6, sum);
        }
    }
}
