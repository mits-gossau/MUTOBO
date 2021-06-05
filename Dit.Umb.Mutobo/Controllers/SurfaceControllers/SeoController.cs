using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.SurfaceControllers
{
    public class SeoController : SurfaceController
    {
        private readonly ISeoService _seoService;

        public SeoController(ISeoService seoService)
        {
            _seoService = seoService;
        }

        // GET: Seo
        public ActionResult Index()
        {
            return View("~/Views/Partials/SEOConfiguration.cshtml",
                _seoService.GetSeoConfiguration(CurrentPage));
        }
    }
}