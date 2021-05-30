using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Services;
using OpenHtmlToPdf;
using Umbraco.Web.Composing;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class PdfGeneratorController : SurfaceController
    {
        private readonly IPdfService _pdfService;



        public PdfGeneratorController(IPdfService classicsPdfService)
        {
            _pdfService = classicsPdfService;
        }


        // GET: PdfGenerator
        [System.Web.Mvc.HttpGet]
        public ActionResult GetPdf()
        {
            return new EmptyResult();
        }
    }
}