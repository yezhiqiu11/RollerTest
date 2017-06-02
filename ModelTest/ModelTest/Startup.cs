using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelTest.Startup))]
namespace ModelTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
