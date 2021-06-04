using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Web.Composing;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.SurfaceControllers
{
    public class PdfGeneratorController : SurfaceController
    {
        private readonly IPdfService _pdfService;



        public PdfGeneratorController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }


        // GET: PdfGenerator
        [System.Web.Mvc.HttpGet]
        public ActionResult GetPdf()
        {
            return new EmptyResult();
        }
    }
}