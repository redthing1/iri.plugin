using System;
using CookieIoC;

namespace Iri.Plugin.Tests.Types
{
    internal class CookiePlugin : ITestPlugin
    {
        public void BeforeActivation(CookieJar container)
        {
            throw new NotImplementedException();
        }

        public int DoFoo(int a, int b)
        {
            return a * 8 + b * 6;
        }
    }
}
