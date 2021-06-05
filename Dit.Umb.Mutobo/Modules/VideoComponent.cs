using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class VideoComponent : MutoboContentModule, ISliderItem, IVideoComponent, IModule
    {
        public Video Video => this.HasValue(DocumentTypes.VideoComponent.Fields.VideoFile)
            ? new Video()
            {
                Source = this.Value<IPublishedContent>(DocumentTypes.VideoComponent.Fields.VideoFile).MediaUrl()
            }
            : null;

        public String Embedded => this.HasValue(DocumentTypes.VideoComponent.Fields.Embedded)
            ? this.Value<string>(DocumentTypes.VideoComponent.Fields.Embedded)
            : null;

        public String Text => this.HasValue(DocumentTypes.VideoComponent.Fields.Text)
            ? this.Value<string>(DocumentTypes.VideoComponent.Fields.Text)
            : null;


        public int? Width => this.HasValue(DocumentTypes.VideoComponent.Fields.Width)
            ? this.Value<int?>(DocumentTypes.VideoComponent.Fields.Width)
            : null;



        public int? Height => this.HasValue(DocumentTypes.VideoComponent.Fields.Height)
            ? this.Value<int?>(DocumentTypes.VideoComponent.Fields.Height)
            : null;


        public VideoComponent(IPublishedElement content) : base(content)
        {
        }



        public IHtmlString RenderIFrame(int? width=null, int? height=null)
        {
            var newWidth = width ?? Width;
            var newHeight = height ?? Height;
            var result = Embedded;

            if (newWidth.HasValue)
                result = Regex.Replace(result.ToLower(), "width=\"([0-9]{1,4})\"", $"width=\"{newWidth}\"");
            if (newHeight.HasValue)
                result = Regex.Replace(result.ToLower(), "height=\"([0-9]{1,4})\"", $"height=\"{newHeight}\"");

            return new HtmlString(result);
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            bld.Append(helper.Partial("~/Views/Partials/VideoComponent.cshtml", this));

            if (SpacerAfterModule)
            {
                bld.Append("<div class=\"spacer\"></div>");
            }

            return new HtmlString(bld.ToString());
        }
    }
}
