using Osmium.PluginEngine.Types;

namespace Iri.Plugin.Tests.Types
{
    interface ITestPlugin : IOsmiumPlugin
    {
        int DoFoo(int a, int b);
    }
}
