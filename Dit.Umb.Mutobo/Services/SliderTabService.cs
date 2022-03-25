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
        protected readonly IVideoService _videoService;


        public SliderTabService(IMutoboSimpleContentService contentService, IImageService imageService, IVideoService videoService)
        {
            _contentService = contentService;
            _imageService = imageService;
            _videoService = videoService;
        }

        public IEnumerable<SliderTab> GetTabs(IPublishedElement content, string fieldName)
        {
            if (!content.HasValue(fieldName))
                return null;

            var result = new List<SliderTab>();

            foreach (var tab in content.Value<IEnumerable<IPublishedContent>>(fieldName))
            {
                SliderTab t = new SliderTab(tab)
                {
                    Modules = _contentService.GetSimpleContent(tab, DocumentTypes.SliderTab.Fields.Modules),
                    BackgroundImg = tab.HasValue(DocumentTypes.SliderTab.Fields.BackgroundImg)
                        ? _imageService.GetImage(tab.Value<IPublishedContent>(DocumentTypes.SliderTab.Fields.BackgroundImg))
                        : null
                };

                if (tab.HasValue(DocumentTypes.SliderTab.Fields.Media))
                {
                    var node = tab.Value<IEnumerable<IPublishedElement>>(DocumentTypes.SliderTab.Fields.Media).FirstOrDefault();
                    try
                    {
                        //t.MediaImg = _imageService.GetImage(node);
                    }
                    catch
                    {
                        try
                        {
                            //t.MediaVideo = _videoService.GetVideo(node);
                        }
                        catch { }
                    }
                }

                result.Add(t);
            }

            return result;
        }
    }
}
