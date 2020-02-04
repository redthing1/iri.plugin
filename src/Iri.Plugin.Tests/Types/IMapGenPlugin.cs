using Osmium.PluginEngine.Types;

namespace Iri.Plugin.Tests.Types
{
    internal interface IMapGenPlugin : IOsmiumPlugin
    {
        string Name { get; }
    }
}
