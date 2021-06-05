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
    public class Accordeon : MutoboContentModule, IModule
    {

        public string Summary => this.HasValue(DocumentTypes.Accordeon.Fields.Summary)
            ? this.Value<string>(DocumentTypes.Accordeon.Fields.Summary)
            : null;
        public string Details => this.HasValue(DocumentTypes.Accordeon.Fields.Details)
            ? this.Value<string>(DocumentTypes.Accordeon.Fields.Details)
            : null;



        public Accordeon(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/Accordeon.cshtml", this));

            if (SpacerAfterModule)
            {
                bld.Append("<div class=\"spacer\"></div>");
            }
            return new MvcHtmlString(bld.ToString());
        }
    }
}
