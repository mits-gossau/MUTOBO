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
  

4. Run the project (inside visual studio on IIS express (ctrl+F5), or on a IIS Site pepared before)
5. Make the umbraco installation (DON'T install the example Website)
6. In the Umbraco-Backend on the settings Tab perform a Usync Import
7. Build your Website and enjoy


Urgent! if you decide to use the web-components-cms templates you must update the submodule

 git submodule update --init --recursive --remote
 
 


