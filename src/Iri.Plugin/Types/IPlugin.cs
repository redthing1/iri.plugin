using CookieIoC;

namespace Iri.Plugin.Types {
    public interface IOsmiumPlugin {
        void BeforeActivation(CookieJar container);
    }
}