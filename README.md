AADx APIs (.net Standard)
=========================
This project is part of the Azure AD authentication model and provides two APIs, each
in a separate project.  Each API is constucted using asp.net Standard 4.61

## Step A
 - No authentication is implemeted
 - CORS is enabled for all origins

## Steps for Basic Behavior and CORS

1) Implement 2 separate webapi projects

2) In each project create controllers with basic crud behavior using entity framework

3) Install Owin Packages

Install the following packages

	Install-Package Microsoft.Owin
	Install-Package Microsoft.Owin.Cors

4) Set Owin startup and enable CORS

In each API, create a Startup.cs class (under App_Start), set the Owin startup class and enable cors in that class

    [assembly: OwinStartup(typeof(MY.NAMESPACE.App_Start.Startup))]

    namespace MY.NAMESPACE.App_Start
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            }
        }
    }


