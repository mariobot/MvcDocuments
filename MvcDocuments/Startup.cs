using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcDocuments.Startup))]
namespace MvcDocuments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
