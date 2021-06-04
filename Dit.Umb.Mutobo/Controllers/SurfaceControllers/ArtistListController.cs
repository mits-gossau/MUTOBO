using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class ArtistListController : SurfaceController
    {
        // GET: ArtistList
        public ActionResult Index()
        {
            return View("~/Views/");
        }
    }
}