using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers
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