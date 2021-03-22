using Dit.Umb.ToolBox.Services;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers
{
    public class XmlSitemapController : RenderMvcController
    {
        private readonly IXmlSitemapServicecs _xmlSitemapService;

        public XmlSitemapController(IXmlSitemapServicecs xmlSitemapServicecs)
        {
            _xmlSitemapService = xmlSitemapServicecs;
        }

        // GET: XmlSitemap
        public ActionResult Index(ContentModel model)
        {
            return View("~/Views/XmlSiteMap.cshtml", _xmlSitemapService.GetXmlSitemap(model.Content));
        }
    }
}