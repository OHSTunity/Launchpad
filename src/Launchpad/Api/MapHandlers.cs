using Starcounter;

namespace Launchpad.Api
{
    internal class MapHandlers
    {
        public void Register()
        {
            UriMapping.Map("/launchpad/applications", UriMapping.MappingUriPrefix + "/app-name");
        }
    }
}
