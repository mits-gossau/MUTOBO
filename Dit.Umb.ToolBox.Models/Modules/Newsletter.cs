using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Modules;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class Newsletter : MutoboContentModule
    {
        public string Information => this.HasValue(DocumentTypes.Newsletter.Fields.Information)
            ? this.Value<string>(DocumentTypes.Newsletter.Fields.Information)
            : null;

        public string Frequency => this.HasValue(DocumentTypes.Newsletter.Fields.Frequency)
            ? this.Value<string>(DocumentTypes.Newsletter.Fields.Frequency)
            : null;

        public string MessageSucess => this.HasValue(DocumentTypes.Newsletter.Fields.MessageSuccess)
            ? this.Value<string>(DocumentTypes.Newsletter.Fields.MessageSuccess)
            : null;

        public string MessageError => this.HasValue(DocumentTypes.Newsletter.Fields.MessageError)
            ? this.Value<string>(DocumentTypes.Newsletter.Fields.MessageError)
            : null;

        public NewsletterForm Form { get; set; }

        public Newsletter(IPublishedElement content) : base(content)
        {
        }
    }
}
