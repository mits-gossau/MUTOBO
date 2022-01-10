# MUTOBO
The friendly CMS-Toolbox based on Umbraco
https://mutobo.ch

to run MUTOBO:

1. Checkout the Repo
2. Build the Repo with Visual Studio
3. Make sure that you have the follwing settings:

- web-project -> web.config appSettings\Umbraco.Core.ConfigurationStatus => set the value to empty string "" 
- web-project -> \config\connectionStrings.config => remove the whole tag:
  <add name="umbracoDbDSN" connectionString="Data Source=|DataDirectory|\Umbraco.sdf;Flush Interval=1;" providerName="System.Data.SqlServerCe.4.0" /> if it's present
  
4. If you want to integrate "Azure Active Directory Login" you must install following Nuget-Package:
   - Install-Package UmbracoCms.IdentityExtensions.AzureActiveDirectory
   - Configure Azure AD - read more in this Post: https://shazwazza.com/post/configuring-azure-active-directory-login-with-umbraco/
   - the used Configuration/Settings are prepared in the appSettings.config

5. Run the project (inside visual studio on IIS express (ctrl+F5), or on a IIS Site pepared before)
6. Make the umbraco installation (DON'T install the example Website)
7. In the Umbraco-Backend on the settings Tab perform a Usync Import
8. Build your Website and enjoy


Urgent! if you decide to use the web-components-cms templates you must update the submodule

 git submodule update --init --recursive --remote
 
 


