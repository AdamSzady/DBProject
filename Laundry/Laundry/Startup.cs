using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laundry.Startup))]
namespace Laundry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
