using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTest1.Startup))]
namespace MvcTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
