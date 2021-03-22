using System.Collections.Generic;
using Dit.Umb.MKulturProzent.Classics.Models.Enums;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{



    public class Teaser : MutoboContentModule
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
    }
}
