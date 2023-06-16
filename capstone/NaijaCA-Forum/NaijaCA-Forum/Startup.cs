using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NaijaCA_Forum.Startup))]
namespace NaijaCA_Forum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
