using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simhopp_WebApplication.Startup))]
namespace Simhopp_WebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
