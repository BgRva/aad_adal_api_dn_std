using AADx.EventsApi.DAL;
using System.Data.Entity;
using System.Web.Http;

namespace AADx.EventsApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<EventContext>(new EventContextInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
