using AADx.TodoApi.DAL;
using System.Data.Entity;
using System.Web.Http;

namespace AADx.TodoApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<TodoContext>(new TodoContextInitializer());
            Database.SetInitializer<UserContext>(new UserContextInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
