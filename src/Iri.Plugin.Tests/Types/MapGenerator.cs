using CookieIoC;
using Iri.Plugin.Tests.Types.MapGen;

namespace Iri.Plugin.Tests.Types
{
    internal class MapGenerator
    {
        public CookieJar Container { get; }

        private PluginLoader<IMapGenPlugin> _pluginLoader;

        public MapGenerator(CookieJar container)
        {
            Container = container;
            _pluginLoader = new PluginLoader<IMapGenPlugin>();
        }

        public void LoadPlugins()
        {
            _pluginLoader.Load(new StupidMapGenPlugin());
            foreach (var plugin in _pluginLoader.Plugins)
            {
                plugin.BeforeActivation(Container);
            }
        }

        public int[] Run()
        {
            // Create default map
            var map = new int[12];
            // Load registered modifiers
            var modifiers = Container.ResolveAll<IMapModifier>();
            foreach (var mod in modifiers)
            {
                mod.Apply(map);
            }
            return map;
        }
    }
}
