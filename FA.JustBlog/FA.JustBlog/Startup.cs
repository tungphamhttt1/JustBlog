using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FA.JustBlog.Startup))]
namespace FA.JustBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
