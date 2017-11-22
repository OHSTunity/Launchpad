using Starcounter;
using Launchpad.ViewModels;

namespace Launchpad.Api
{
    internal class MainHandlers
    {
        public void Register()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/launchpad", () =>
            {
                var master = this.GetMasterPageFromSession();

                if (!(master.CurrentPage is LaunchpadPage))
                {
                    master.CurrentPage = Self.GET("/launchpad/partial/launchpad");
                }
                return master;
            });

            Handle.GET("/launchpad/partial/launchpad", () =>
            {
                string layout = Layout.GetSetup("/Launchpad")?.Value;
                if (layout == null)
                {
                    // workaround for https://github.com/Starcounter/Starcounter/issues/3072
                    // set default value
                    // consider moving to HTML, or pre-populatind default layouts
                    layout = "{\"width\": \"1000\", \"items\":[]}";
                }

                return new LaunchpadPage
                {
                    Applications = Self.GET<Json>("/launchpad/applications"),
                    Layout = layout
                };
            }, new HandlerOptions { SelfOnly = true });

            Handle.GET("/launchpad/applications", () => new Json());

            Handle.GET("/launchpad/settings", () =>
            {
                var master = this.GetMasterPageFromSession();

                master.CurrentPage = Self.GET("/launchpad/partial/settings");

                return master;
            });

            Handle.GET("/launchpad/partial/settings", () => new SettingsPage());

            Blender.MapUri("/launchpad/partial/launchpad", string.Empty, new string[] { "launchpad" }); // launchpad panel; used in Launcher/Website
            Blender.MapUri("/launchpad/partial/settings", string.Empty, new string[] { "settings" });
        }


        protected MasterPage GetMasterPageFromSession()
        {
            if (Session.Current == null)
            {
                Session.Current = new Session(SessionOptions.PatchVersioning);
            }

            MasterPage master = Session.Ensure().Store[nameof(MasterPage)] as MasterPage;

            if (master == null)
            {
                master = new MasterPage();
                Session.Current.Store[nameof(MasterPage)] = master;
            }

            return master;
        }
    }
}