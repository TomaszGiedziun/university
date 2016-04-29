using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(notatka.Startup))]
namespace notatka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
