using Dit.Umb.ToolBox.Services;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class SeoController : SurfaceController
    {
        private readonly IConfigurationService _configurationService;

        public SeoController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        // GET: Seo
        public ActionResult Index()
        {
            return View("~/Views/Partials/SEOConfiguration.cshtml",
                _configurationService.GetSeoConfiguration(CurrentPage));
        }
    }
}