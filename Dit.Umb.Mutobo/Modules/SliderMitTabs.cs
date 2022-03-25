using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class SliderMitTabs : MutoboContentModule
    {
        public string Title => this.HasValue(DocumentTypes.SliderMitTabs.Fields.Title)
            ? this.Value<string>(DocumentTypes.SliderMitTabs.Fields.Title)
            : string.Empty;
        
        public string Info => this.HasValue(DocumentTypes.SliderMitTabs.Fields.Info)
            ? this.Value<string>(DocumentTypes.SliderMitTabs.Fields.Info)
            : string.Empty;

        public IEnumerable<SliderTab> Tabs { get; set; }


        public string BackgroundColor => this.HasValue(DocumentTypes.SliderMitTabs.Fields.BackgroundColor)
            ? this.Value<string>(DocumentTypes.SliderMitTabs.Fields.BackgroundColor)
            : string.Empty;

        public Image BackgroundImg { get; set; }

        public bool BackgroundFix => this.Value<bool>(DocumentTypes.SliderMitTabs.Fields.BackgroundFix);

        public SliderMitTabs(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/Modules/SliderMitTabs.cshtml", this));
            return new MvcHtmlString(bld.ToString());
        }
    }
}
