using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class CssVariablesController : SurfaceController
    {
        // GET: CssVariables
        public ActionResult Index(ITheme theme)
        {
            return View("~/Views/Partials/CssVariables.cshtml", theme);
        }
    }
}