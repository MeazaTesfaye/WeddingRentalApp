using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeddingRental.WebMVC.Startup))]
namespace WeddingRental.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
