using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAce.Startup))]
namespace TestAce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
