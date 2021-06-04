using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{



    public class Teaser : MutoboContentModule, IModule
    {
        public Umbraco.Web.Models.Link Link => this.HasValue(DocumentTypes.Teaser.Fields.Link)
            ? this.Value<Umbraco.Web.Models.Link>(DocumentTypes.Teaser.Fields.Link)
            : null;

        public IEnumerable<Image> Images { get; set; }

        public bool UseArticleData => this.HasValue(DocumentTypes.Teaser.Fields.UseArticleData) && this.Value<bool>(DocumentTypes.Teaser.Fields.UseArticleData);

        public string TeaserTitle { get; set; }

        public string TeaserText { get; set; }

        public EHighlightRendering RenderAs => this.HasValue(DocumentTypes.Teaser.Fields.RenderAs)
            ? (EHighlightRendering) System.Enum.Parse(typeof(EHighlightRendering),
                this.Value<string>(DocumentTypes.Teaser.Fields.RenderAs))
            : EHighlightRendering.None;

        public Teaser(IPublishedElement content) : base(content)
        {


        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            switch (RenderAs)
            {
                case EHighlightRendering.Teaser:
                    bld.Append(helper.Partial("~/Views/Partials/NestedTeaser.cshtml", this));
                    break;
                default:
                case EHighlightRendering.Gallery:
                    bld.Append(helper.Partial("~/Views/Partials/GalleryTeaser.cshtml", this));
                    break;
            }

            if (SpacerAfterModule)
            {
                bld.Append("<div class=\"spacer\"></div>");
            }

            return new MvcHtmlString(bld.ToString());
        }
    }
}
