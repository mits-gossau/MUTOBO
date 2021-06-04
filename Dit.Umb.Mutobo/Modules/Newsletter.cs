using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using ImageProcessor.Web.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using IImageService = Dit.Umb.Mutobo.Interfaces.IImageService;

namespace Dit.Umb.Mutobo.Modules
{
    public class Newsletter : MutoboContentModule, IModule
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

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            var imageService =
                (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            bld.Append(helper.Partial("~/Views/Partials/Newsletter.cshtml", this));

            return new HtmlString(bld.ToString());
        }
    }
}
