using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fixcar_web.Startup))]
namespace fixcar_web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
