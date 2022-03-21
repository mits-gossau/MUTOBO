using System;
using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Mutobo.Common;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Modules;
using Dit.Umb.Mutobo.PageModels;
using Dit.Umb.Mutobo.PoCo;
using NUglify.Helpers;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using DocumentTypes = Dit.Umb.Mutobo.Constants.DocumentTypes;

namespace Dit.Umb.Mutobo.Services
{
    public class MutoboSimpleContentService : BaseService, IMutoboSimpleContentService
    {
        protected readonly IImageService ImageService;
        protected readonly ISliderService SliderService;
        protected readonly IConfigurationService ConfigurationService;

        public MutoboSimpleContentService(
            IImageService imageService,
            ISliderService sliderService,
            IConfigurationService configurationService)
        {
            ImageService = imageService;
            SliderService = sliderService;
            ConfigurationService = configurationService;
        }

        public virtual IEnumerable<MutoboContentModule> GetSimpleContent(IPublishedContent content, string fieldName)
        {
            if (content.HasValue(fieldName))
            {
                var result = new List<MutoboContentModule>();

                var elements =
                    content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var element in elements.Select((value, index) => new { index, value }))
                {
                    switch (element.value.ContentType.Alias)
                    {
                        case DocumentTypes.Heading.Alias:
                            result.Add(new Heading(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.VideoComponent.Alias:
                            result.Add(new VideoComponent(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.RichTextComponent.Alias:
                            result.Add(new RichtextComponent(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.PictureModule.Alias:
                            var picModule = new PictureModule(element.value)
                            {
                                SortOrder = element.index
                            };
                            var isGoldenRatio = (picModule.Height == null && picModule.Width == null);
                            picModule.Image = element.value.HasValue(DocumentTypes.Picture.Fields.Image)
                                ? ImageService.GetImage(
                                    element.value.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image),
                                    height: picModule.Height,
                                    width: picModule.Width)
                                : null;
                            result.Add(picModule);
                            break;
                    }
                }

                return result;
            }

            return null;
        }
    }
}
