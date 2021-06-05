using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.NonUmbraco
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

            if (true)
            {
                Session["cachedJS"] = _scriptService.GetWebComponentsBundled();
                cached = Session["cachedJS"].ToString();
            }
            return View("~/Views/NonUmbraco/WCScriptsView.cshtml", new ScriptModel(){ Script = cached });
        }
    }
}