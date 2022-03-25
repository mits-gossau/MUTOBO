using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
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
}
