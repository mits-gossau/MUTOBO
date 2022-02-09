using System.Text;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class RichtextComponent : MutoboContentModule
    {
        public string RichText => this.HasValue(DocumentTypes.RichTextComponent.Fields.RichText)
            ? this.Value<string>(DocumentTypes.RichTextComponent.Fields.RichText)
            : string.Empty;

        public RichtextComponent(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            Anchor = Anchor != string.Empty ? $"id ={Anchor}" : "";

            var bld = new StringBuilder();
            bld.Append($"<article {Anchor}>{helper.Raw(RichText)}</article>");
            return new MvcHtmlString(bld.ToString());
        }
    }
}
