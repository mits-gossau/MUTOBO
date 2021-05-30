using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Microsoft.Ajax.Utilities;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class Heading : MutoboContentModule
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
    }
}
