using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTrackingTool.Startup))]
namespace ProjectTrackingTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
