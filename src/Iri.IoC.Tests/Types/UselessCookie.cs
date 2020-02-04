namespace Iri.IoC.Tests.Types
{
    internal class UselessCookie : IUselessThing
    {
        public string DoSomethingUseless()
        {
            return nameof(UselessCookie);
        }
    }
}