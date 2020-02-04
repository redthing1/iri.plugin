using Iri.IoC;

namespace Iri.Plugin.Types {
    public interface IPlugin {
        void BeforeActivation(CookieJar container);
    }
}