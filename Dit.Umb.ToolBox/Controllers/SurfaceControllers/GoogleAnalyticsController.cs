using System.Linq;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class GoogleAnalyticsController : SurfaceController
    {
        // GET: GoogleAnalytics
        public ActionResult Index()
        {
            var homePage = Umbraco.AssignedContentItem.AncestorsOrSelf().FirstOrDefault(c =>
                c.ContentType.Alias == DocumentTypes.HomePage.Alias);

            var code = homePage?.Value<string>(DocumentTypes.BasePage.Fields.GoogleAnalyticsKey) ?? string.Empty;
            
            if (homePage == null)
                return new EmptyResult();

            return View("~/Views/Partials/GoogleAnalytics.cshtml", new GoogleAnalyticsModel()
            {
                Key = code

            });
        }
    }
}