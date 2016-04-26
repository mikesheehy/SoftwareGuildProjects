using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDLibrary.Startup))]
namespace DVDLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
