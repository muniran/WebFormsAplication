using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsAplication.Startup))]
namespace WebFormsAplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
