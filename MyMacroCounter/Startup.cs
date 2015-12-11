using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMacroCounter.Startup))]
namespace MyMacroCounter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
