using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class VideoComponent : MutoboContentModule, ISliderItem, IVideoComponent
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


    }
}
