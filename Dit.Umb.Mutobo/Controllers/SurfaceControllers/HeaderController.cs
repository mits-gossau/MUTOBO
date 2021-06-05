using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.SurfaceControllers
{
    public class HeaderController : SurfaceController
    {
        private readonly IPageLayoutService _pageLayoutService;


        public HeaderController(IPageLayoutService pageLayoutService)
        {
            _pageLayoutService = pageLayoutService;
        }

        public ActionResult Index()
        {
            return View("~/Views/Partials/Header.cshtml", _pageLayoutService.GetHeaderConfiguration());
        }
    }
}