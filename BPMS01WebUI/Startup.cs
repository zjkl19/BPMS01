using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPMS01WebUI.Startup))]
namespace BPMS01WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
