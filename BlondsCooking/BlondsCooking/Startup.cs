using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlondsCooking.Startup))]
namespace BlondsCooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
