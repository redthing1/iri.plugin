using Iri.IoC;
using Iri.Plugin.Tests.Types.MapGen;

namespace Iri.Plugin.Tests.Types
{
    internal class StupidMapGenPlugin : IMapGenPlugin
    {
        public string Name => "Stupid Mapgen";

        public void BeforeActivation(CookieJar container)
        {
            container.Register<IMapModifier>(new AlternatingModifier());
            container.Register<IMapModifier>(new FirstFiveModifier());
        }
    }
}
