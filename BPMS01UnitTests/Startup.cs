using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPMS01UnitTests.Startup))]
namespace BPMS01UnitTests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
