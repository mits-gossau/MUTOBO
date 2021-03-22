using Dit.Umb.ToolBox.Services;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
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