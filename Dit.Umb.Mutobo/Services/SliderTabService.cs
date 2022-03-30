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
    public class SliderTabService : ISliderTabService
    {
        protected readonly IMutoboSimpleContentService _contentService;
        protected readonly IImageService _imageService;

        public SliderTabService(IMutoboSimpleContentService contentService, 
            IImageService imageService)
        {
            _contentService = contentService;
            _imageService = imageService;
        }

        public IEnumerable<SliderTab> GetTabs(IPublishedElement content, string fieldName)
        {
            if (!content.HasValue(fieldName))
                return null;

            var result = new List<SliderTab>();

            foreach (var tab in content.Value<IEnumerable<IPublishedContent>>(fieldName)
                .Select((value, index) => new { index, value }))
            {
                result.Add(new SliderTab(tab.value)
                {
                    DataId = tab.index,
                    Modules = _contentService.GetSimpleContent(tab.value, DocumentTypes.SliderTab.Fields.Modules),
                    BackgroundImg = tab.value.HasValue(DocumentTypes.SliderTab.Fields.BackgroundImg)
                        ? _imageService.GetImage(
                            tab.value.Value<IPublishedContent>(DocumentTypes.SliderTab.Fields.BackgroundImg))
                        : null,
                    Media = tab.value.HasValue(DocumentTypes.SliderTab.Fields.Media)
                        ? _contentService.GetSimpleContent(
                            tab.value, DocumentTypes.SliderTab.Fields.Media).FirstOrDefault()
                        : null
                });
            };

            return result;
        }
    }
}
