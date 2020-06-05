using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrypticCities.Startup))]
namespace CrypticCities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
