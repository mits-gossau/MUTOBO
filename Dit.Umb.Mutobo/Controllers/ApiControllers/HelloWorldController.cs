using System.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Dit.Umb.Mutobo.Controllers.ApiControllers
{
    public class HelloWorldController : UmbracoApiController
    {

        [HttpGet]
        // GET: HelloWorld
        public object GetHello(string lang = null)
        {
            return new
            {
                Text = "Hello from Umbraco Web API",
                Zahl = 1,
                Title = "Hello World"
            };
        }
    }
}