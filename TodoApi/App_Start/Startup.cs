using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AADx.TodoApi.Startup))]

namespace AADx.TodoApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);     
        }
    }
}