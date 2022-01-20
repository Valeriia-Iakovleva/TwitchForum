using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitchForum.Startup))]

namespace TwitchForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}