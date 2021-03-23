using System;
using System.Collections.Generic;
using Dit.Umb.Toolbox.Common.ContentExtensions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class MutoboContentService : BaseService, IMutoboContentService
    {

        private readonly IImageService _imageService;

        public MutoboContentService(IImageService imageService)
        {
            _imageService = imageService;
        }


        public IEnumerable<MutoboContentModule> GetContent(IPublishedContent content, string fieldName)
        {


            if (content.HasValue(fieldName))
            {
                var result = new List<MutoboContentModule>();

                var elements =
                    content.Value<IEnumerable<IPublishedElement>>(fieldName);

              

                foreach (var element in elements)
                {

                    switch (element.ContentType.Alias)
                    {
                        case DocumentTypes.Heading.Alias:
                            result.Add(new Heading(element));
                            break;
                        case DocumentTypes.VideoComponent.Alias:
                            result.Add(new VideoComponent(element));
                            break;
                        case DocumentTypes.RichTextComponent.Alias:
                            result.Add(new RichtextComponent(element));
                            break;

                        case DocumentTypes.Flyer.Alias:
                            result.Add(new Flyer(element)
                            {
                                Image = element.GetImage(DocumentTypes.Flyer.Fields.FlyerImage, 
                                    element.Value<int?>(DocumentTypes.Flyer.Fields.Width), 
                                    element.Value<int?>(DocumentTypes.Flyer.Fields.Height)),
                                TeaserText = element.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText),
                            });
                            break;

                        case DocumentTypes.Teaser.Alias:
                            result.Add(GetTeaser(element));
                            break;

                      
                    }



                }

                return result;
            }

            return null;
        }


        private Teaser GetTeaser(IPublishedElement element)
        {
            
            var teaser = new Teaser(element);


            if (teaser.UseArticleData)
            {
                var article = teaser.Link?.Udi != null ?
                    new ArticlePage(Helper.Content(teaser.Link.Udi)) : null;

                if (article == null)
                    throw new Exception($"Please make sure that you have a linked article page when using article data.");

              
            }
            else
            {
                teaser.Images = element.HasValue(DocumentTypes.Teaser.Fields.Images)
                    ? _imageService.GetImages(
                        element.Value<IEnumerable<IPublishedContent>>(DocumentTypes.Teaser.Fields.Images))
                    : null;
                teaser.TeaserText = element.HasValue(DocumentTypes.Teaser.Fields.TeaserText) ?
                    element.Value<string>(DocumentTypes.Teaser.Fields.TeaserText) : null;

                teaser.TeaserTitle = element.HasValue(DocumentTypes.Teaser.Fields.TeaserTitle) ?
                    element.Value<string>(DocumentTypes.Teaser.Fields.TeaserTitle) : null;
            }


            return teaser;

        }



    }
}
