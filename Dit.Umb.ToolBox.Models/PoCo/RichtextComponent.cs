using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class RichtextComponent : MutoboContentModule
    {
        public string RichText => this.HasValue(DocumentTypes.RichTextComponent.Fields.RichText)
            ? this.Value<string>(DocumentTypes.RichTextComponent.Fields.RichText)
            : string.Empty;

        public RichtextComponent(IPublishedElement content) : base(content)
        {
        }
    }
}
