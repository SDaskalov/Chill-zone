using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(ChillZone.Web.Startup))]

namespace ChillZone.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
