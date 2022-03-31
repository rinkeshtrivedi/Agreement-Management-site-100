using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Agreement.Startup))]
namespace Web.Agreement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
