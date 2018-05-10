AADx APIs (.net Standard)
=========================
This project is part of the Azure AD authentication model and provides two APIs, each
in a separate project.  Each API is constucted using asp.net Standard 4.61

## Step B
Baseline integration with Azure AD

## Changes from Step_A
Start with branch Step_A and make the following changes

1) Register Each API in AAD

In AAD, register each API as a separate application and record the following
 - tenenant id
 - application id
 - application id uri

2) Install Packages

In each API project, install the following packages


	Install-Package Microsoft.Owin.Security
	Install-Package Microsoft.Owin.Security.ActiveDirectory
	Install-Package Microsoft.IdentityModel.Logging
	Install-Package Microsoft.IdentityModel.Protocols.WsFederation

3) Add AAD Properties

In each API project web.config file, add the following to appSettings and set 
the value of each to the appropriate AAD app registration value


    <add key="ida:Tenant" value="Enter your tenant name here e.g. contoso.onmicrosoft.com" />
    <add key="ida:Audience" value="Enter the App ID URI of the To Go API here, e.g. https://contoso.onmicrosoft.com/994-33334-5245" />

4) Enable Auth Middleware

Modify Starup.cs to enable auth:


    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Audience = ConfigurationManager.AppSettings["ida:Audience"],
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                });
        }
    }

5) Enforce Auth at Controllers

To each controller add the ```[Authorize]``` attribute at the class level


6) Allow One Exception

In the _EventsApi_ controller, allow anonymous access to the _GetEventItems()_ endpoint:


    [AllowAnonymous]
    // GET: api/Event
    public IQueryable<EventItem> GetEventItems()
    {
    	logger.Debug("returning all ...");
    	return db.EventItems;
    }
    
    
