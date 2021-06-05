using System.Text;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class Heading : MutoboContentModule, IModule
    {
        public string Text => this.HasValue(DocumentTypes.Heading.Fields.Text)
            ? this.Value<string>(DocumentTypes.Heading.Fields.Text)
            : string.Empty;

        public EHeadingRenderType RenderAs => this.HasValue(DocumentTypes.Heading.Fields.RenderAs)
            ?  (EHeadingRenderType)System.Enum.Parse(typeof(EHeadingRenderType), this.Value<string>(DocumentTypes.Heading.Fields.RenderAs)) 
            : EHeadingRenderType.Heading1;

        public string NavigationAnchor => this.HasValue(DocumentTypes.Heading.Fields.NavigationAnchor)
            ? this.Value<string>(DocumentTypes.Heading.Fields.NavigationAnchor)
            : null;

        public Heading(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

                var anchor = $"id=\"{NavigationAnchor}\"" ?? string.Empty;

                switch (RenderAs)
                {
                    case EHeadingRenderType.Heading1:
                        bld.Append($"<h1 {anchor}>{Text.ToUpper()}</h1>");
                        break;
                    case EHeadingRenderType.Heading2:
                        bld.Append($"<h2 {anchor}>{Text.ToUpper()}</h2>");
                        break;
                    case EHeadingRenderType.Heading3:
                        bld.Append($"<h3 {anchor}>{Text.ToUpper()}</h3>");
                        break;
                    case EHeadingRenderType.Heading4:
                        bld.Append($"<h4 {anchor}>{Text.ToUpper()}</h4>");
                        break;
                    case EHeadingRenderType.Heading5:
                        bld.Append($"<h5 {anchor}>{Text.ToUpper()}</h5>");
                        break;
                    case EHeadingRenderType.Heading6:
                        bld.Append($"<h6 {anchor}>{Text.ToUpper()}</h6>");
                        break;
                }

            return new MvcHtmlString(bld.ToString());
        }
    }
}
