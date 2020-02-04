using Iri.Plugin.Types;

namespace Iri.Plugin.Tests.Types
{
    interface ITestPlugin : IPlugin
    {
        int DoFoo(int a, int b);
    }
}
