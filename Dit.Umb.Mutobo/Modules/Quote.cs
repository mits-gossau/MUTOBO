using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class Quote : MutoboContentModule, IModule
    {

        public string QuoteText => this.HasValue(DocumentTypes.Quote.Fields.QuoteText)
            ? this.Value<string>(DocumentTypes.Quote.Fields.QuoteText)
            : string.Empty;

        public string SpellerName => this.HasValue(DocumentTypes.Quote.Fields.SpellerName)
            ? this.Value<string>(DocumentTypes.Quote.Fields.SpellerName)
            : string.Empty;

        public string SpellerFunction => this.HasValue(DocumentTypes.Quote.Fields.SpellerFunction)
            ? this.Value<string>(DocumentTypes.Quote.Fields.SpellerFunction)
            : string.Empty;

        public Quote(IPublishedElement content) : base(content)
        {
        }


        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            var imageService =
                (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            bld.Append(helper.Partial("~/Views/Partials/Modules/Quote.cshtml", this));

            return new MvcHtmlString(bld.ToString());
        }
    }
}
