using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class Heading : MutoboContentModule
    {
        public string Text => this.HasValue(DocumentTypes.Heading.Fields.Text)
            ? this.Value<string>(DocumentTypes.Heading.Fields.Text)
            : string.Empty;

        public Heading(IPublishedElement content) : base(content)
        {
        }
    }
}
