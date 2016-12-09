using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CascadingDropDownApp.Startup))]
namespace CascadingDropDownApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
