using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderDemo.Startup))]
namespace OrderDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
