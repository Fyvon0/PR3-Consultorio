using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPIII.Startup))]
namespace PPIII
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
