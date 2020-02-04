using CookieIoC;
using System;

namespace Iri.Plugin.Tests.Types
{
    internal class MultiplyingPlugin : ITestPlugin
    {
        public MultiplyingPlugin(int factor)
        {
            Factor = factor;
        }

        public int Factor { get; }

        public void BeforeActivation(CookieJar container)
        {
            throw new NotImplementedException();
        }

        public int DoFoo(int a, int b)
        {
            return (a + b) * Factor;
        }
    }
}
