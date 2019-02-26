using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPMVCWebAppSample.Startup))]
namespace ASPMVCWebAppSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
