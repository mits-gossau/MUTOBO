using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Core.Composing;

namespace Dit.Umb.Mutobo.Components
{

    /// <summary>
    /// Custom implemented component to configure the Web-API
    /// </summary>
    public class ApiConfigurationComponent : IComponent
    {
        public void Initialize()
        {
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter()
            {
                SerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });

            
            // Register custom routes for Web-API
            RouteTable.Routes.MapHttpRoute("HeadlessApi", "Headless/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
            //RouteTable.Routes.MapHttpRoute("Artists", "{controller}/{action}/{artistName}", defaults: new { artistName = RouteParameter.Optional });
        }

        public void Terminate()
        {
          
        }
    }
}