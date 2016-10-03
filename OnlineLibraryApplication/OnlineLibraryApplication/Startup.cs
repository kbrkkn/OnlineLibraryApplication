using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineLibraryApplication.Startup))]
namespace OnlineLibraryApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
