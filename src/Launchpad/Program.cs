using Launchpad.Api;

namespace Launchpad
{
    class Program
    {
        static void Main()
        {
            var mainHandlers = new MainHandlers();
            var mapHandlers = new MapHandlers();

            mainHandlers.Register();
            mapHandlers.Register();
        }
    }
}