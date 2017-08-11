using Starcounter;

namespace Launchpad.Api
{
    internal class MapHandlers
    {
        public void Register()
        {
            Blender.MapUri("/launchpad/applications", string.Empty, new string[] { "app", "icon" });
        }
    }
}
