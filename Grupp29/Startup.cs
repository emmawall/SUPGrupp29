using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Grupp29.Startup))]
namespace Grupp29
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
