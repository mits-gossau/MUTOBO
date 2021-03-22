using System;
using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class VideoComponent : MutoboContentModule
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


        public VideoComponent(IPublishedElement content) : base(content)
        {
        }


    }
}
