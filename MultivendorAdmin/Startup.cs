using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultivendorAdmin.Startup))]
namespace MultivendorAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
