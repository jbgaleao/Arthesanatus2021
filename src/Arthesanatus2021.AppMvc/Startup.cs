using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arthesanatus2021.AppMvc.Startup))]
namespace Arthesanatus2021.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
