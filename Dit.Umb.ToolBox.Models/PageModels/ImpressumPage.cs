using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class ImpressumPage : BasePage
    {
        public string HtmlContent => Content.Value<string>(DocumentTypes.ImpressumPage.Fields.HtmlContent);


        public ImpressumPage(IPublishedContent content) : base(content)
        {

        }
    }
}
