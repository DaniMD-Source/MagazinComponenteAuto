using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagazinComponenteAuto.Startup))]
namespace MagazinComponenteAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
