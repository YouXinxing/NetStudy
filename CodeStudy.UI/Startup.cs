using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeStudy.UI.Startup))]
namespace CodeStudy.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
