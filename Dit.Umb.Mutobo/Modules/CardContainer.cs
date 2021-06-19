using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Modules
{
    public class CardContainer : MutoboContentModule, IModule
    {

        public IEnumerable<Card> Cards { get; set; }

        public CardContainer(IPublishedElement content) : base(content)
        {
        }


        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            var imageService =
                (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            bld.Append(helper.Partial("~/Views/Partials/Modules/CardContainer.cshtml", this));

            return new MvcHtmlString(bld.ToString());
        }
    }
}
