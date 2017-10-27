using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VTube.Startup))]
namespace VTube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
