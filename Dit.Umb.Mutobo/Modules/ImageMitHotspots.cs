using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Umbraco.Core.Models.PublishedContent;
using Dit.Umb.Mutobo.PoCo;

namespace Dit.Umb.Mutobo.Modules
{
    public class ImageMitHotspots : MutoboContentModule
    {
        public Image Image { get; set; }
        public IEnumerable<ImageHotspotContainer> Hotspots { get; set; }

        public ImageMitHotspots(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/Modules/ImageMitHotspots.cshtml", this));
            return new MvcHtmlString(bld.ToString());
        }
    }
}
