using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultivendorEcommerceStore.Startup))]
namespace MultivendorEcommerceStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
