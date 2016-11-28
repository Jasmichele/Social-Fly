using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialFly.Startup))]
namespace SocialFly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
