using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Services
{
    public class ImageHotspotService : IImageHotspotService
    {
        protected readonly IMutoboSimpleContentService _contentService;

        public ImageHotspotService(IMutoboSimpleContentService contentService)
        {
            _contentService = contentService;
        }


        public IEnumerable<ImageHotspotContainer> GetImageHotspotContainers(IPublishedElement content, string fieldName)
        {
            if (!content.HasValue(fieldName))
                return null;

            var result = new List<ImageHotspotContainer>();

            foreach (var container in content.Value<IEnumerable<IPublishedElement>>(fieldName))
            {
                result.Add(new ImageHotspotContainer(container)
                {
                    Hotspot = container.HasValue(DocumentTypes.ImageHotspotContainer.Fields.Hotspot) ?
                            new ImageHotspot(container.Value<IPublishedContent>(DocumentTypes.ImageHotspotContainer.Fields.Hotspot))
                            {
                                Modules = _contentService.GetSimpleContent(
                                    container.Value<IPublishedContent>(DocumentTypes.ImageHotspotContainer.Fields.Hotspot),
                                    DocumentTypes.ImageHotspot.Fields.Modules)
                            } : null,
                });
            }

            return result;
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
