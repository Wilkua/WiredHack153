using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WiredHack153Web.Startup))]
namespace WiredHack153Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
