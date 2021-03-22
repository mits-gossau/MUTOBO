using Dit.Umb.ToolBox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class FooterController : SurfaceController
    {
        private readonly IPageLayoutService _pageLayoutService;

        public FooterController(IPageLayoutService pageLayoutService)
        {
            _pageLayoutService = pageLayoutService;
        }

        // GET: Footer
        public ActionResult Index()
        {
            return View("~/Views/Partials/Footer.cshtml", _pageLayoutService.GetFooterConfiguration());
        }
    }
}