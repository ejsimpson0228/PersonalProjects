using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductivityCoach.Startup))]
namespace ProductivityCoach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
