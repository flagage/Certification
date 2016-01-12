using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_bibliotheque.Startup))]
namespace e_bibliotheque
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
