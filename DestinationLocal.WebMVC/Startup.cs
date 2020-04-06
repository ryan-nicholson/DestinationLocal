using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DestinationLocal.WebMVC.Startup))]
namespace DestinationLocal.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
