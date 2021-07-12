using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestePratico.Web.Startup))]
namespace TestePratico.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
