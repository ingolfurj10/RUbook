using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RUbook.Startup))]
namespace RUbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
