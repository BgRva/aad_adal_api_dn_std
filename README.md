AADx APIs (.net framework)
==========================
This project is part of the Azure AD authentication model and provides two APIs, each
in a separate project.  Each API is constucted using asp.net Standard 4.61

This repo is part of the Azure Active Directory (AAD) authentication model and provides a solution with two separate
Web API projects build with .net 4.6.1.  The intention is to use these APIs in conjuncion with a separate UI
project in another repo [BgRva/aad_adal_ui_ng_js](https://github.com/BgRva/aad_adal_ui_ng_js)

This repo has multiple branches, each of which represent different chapters as authentication and authorization are implemented.  Each step builds upon the previous step.  The README file is different for each step and describes the changes with respect to the previous step.  To proceed through all the steps you will need an Azure subscription.  All samples use the default Azure AD features (i.e. free tier).

# Step A
 - No authentication is implemeted
 - CORS is enabled for all origins using Owin middleware
 
 Next step is **Step_B**

## Steps for Basic Behavior and CORS

1) Install the following packages

	Install-Package Microsoft.Owin
	Install-Package Microsoft.Owin.Cors

4) Set Owin startup and enable CORS

In each API, create a Startup.cs class (under App_Start), set the Owin startup class and enable cors in that class

    // this is important and sets the owin middleware to handle startup
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

