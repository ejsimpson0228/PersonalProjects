using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWorkoutLog.UI.Startup))]
namespace MyWorkoutLog.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
