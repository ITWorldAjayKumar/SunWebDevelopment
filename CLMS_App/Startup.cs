using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CLMS_App.Startup))]
namespace CLMS_App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
