using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManoCertWebSite.Startup))]
namespace ManoCertWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
