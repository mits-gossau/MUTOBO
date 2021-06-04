using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PageModels
{
    public class ImpressumPage : BasePage
    {
        public string HtmlContent => Content.Value<string>(DocumentTypes.ImpressumPage.Fields.HtmlContent);


        public ImpressumPage(IPublishedContent content) : base(content)
        {

        }
    }
}
