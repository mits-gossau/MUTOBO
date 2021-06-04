using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Modules;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using DocumentTypes = Dit.Umb.Mutobo.Constants.DocumentTypes;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class SliderService : ISliderService
    {

        private readonly IImageService _imageService;


        public SliderService(IImageService imageService, IConfigurationService configurationService)
        {
            _imageService = imageService;

        }


        public IEnumerable<ISliderItem> GetSlides(IPublishedElement content, string fieldName, int? width = null, int? height = null, bool isGoldenRatio = false)
        {
            var result = new List<ISliderItem>();

            if (content.HasValue(fieldName))
            {
                var slideContent = content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var slideNode in slideContent)
                {
                    if (slideNode.ContentType.Alias == DocumentTypes.VideoComponent.Alias)
                    {
                        var vc = new VideoComponent(slideNode);

                        result.Add(new EmptyVideoComponent()
                        {
                            Height = height,
                            Width = width,
                            Embedded = vc.Embedded,
                            Text = vc.Text,
                            Video = vc.Video
                        });
                    }
                    else if (slideNode.ContentType.Alias == DocumentTypes.Picture.Alias)
                    {
                        result.Add(new Picture()
                        {
                            Image = slideNode.HasValue(DocumentTypes.Picture.Fields.Image) ? _imageService.GetImage(
                                slideNode.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image), width, height, isGoldenRatio: isGoldenRatio) : null
                        });
                    }


                }

            }

            return result;
        }
    }
}
