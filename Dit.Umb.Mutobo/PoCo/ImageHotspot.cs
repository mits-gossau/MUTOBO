using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Modules;
using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.PoCo
{
    public class ImageHotspot : ContentModel
    {
        public string Title => Content.HasValue(DocumentTypes.ImageHotspot.Fields.Title)
            ? Content.Value<string>(DocumentTypes.ImageHotspot.Fields.Title)
            : string.Empty;

        public IEnumerable<MutoboContentModule> Modules { get; set; }

        public ImageHotspot(IPublishedContent content) : base(content)
        {
        }
    }
}
