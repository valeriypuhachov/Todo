using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Todo.WebUI.Startup))]
namespace Todo.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
