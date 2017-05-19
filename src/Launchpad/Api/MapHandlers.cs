using Starcounter;

namespace Launchpad.Api
{
    internal class MapHandlers
    {
        public void Register()
        {
            Blender.MapUri("/launchpad/applications", "app-name");
        }
    }
}
