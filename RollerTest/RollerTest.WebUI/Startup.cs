using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RollerTest.WebUI.Startup))]
namespace RollerTest.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
