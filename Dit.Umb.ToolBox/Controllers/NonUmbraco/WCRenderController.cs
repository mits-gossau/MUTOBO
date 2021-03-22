using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.NonUmbraco
{
    public class WcRenderController : SurfaceController
    {
        private readonly IScriptService _scriptService;


        public WcRenderController(IScriptService scriptService)
        {
            _scriptService = scriptService;
        }


        // GET: WCRender
        public ActionResult Index()
        {
            var cached = Session["cachedJS"]?.ToString();

            if (cached == null)
            {
                Session["cachedJS"] = _scriptService.GetWebComponentsBundled();
                cached = Session["cachedJS"].ToString();
            }
            return View("~/Views/NonUmbraco/WCScriptsView.cshtml", new ScriptModel(){ Script = cached });
        }
    }
}