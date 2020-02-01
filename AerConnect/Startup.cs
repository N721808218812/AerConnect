using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AerConnect.Startup))]
namespace AerConnect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
