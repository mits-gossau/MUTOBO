using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class ImageHotspot : PublishedContentModel
    {
        public string Title => this.HasValue(DocumentTypes.ImageHotspot.Fields.Title)
            ? this.Value<string>(DocumentTypes.ImageHotspot.Fields.Title)
            : string.Empty;

        public IEnumerable<MutoboContentModule> Modules { get; set; }

        public ImageHotspot(IPublishedContent content) : base(content)
        {
        }
    }

    public class Hotspot
    {
        [JsonProperty("left")]
        public int Left { get; set; }
        [JsonProperty("top")]
        public int Top { get; set; }
        [JsonProperty("percentX")]
        public decimal PercentX { get; set; }
        [JsonProperty("percentY")]
        public decimal PercentY { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }

        public override string ToString()
        {
            return "left: " + PercentX + "%; top: " + PercentY + "%;";
        }
    }
}
