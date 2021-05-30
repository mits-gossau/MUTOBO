using System;
using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Toolbox.Common.ContentExtensions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using DocumentTypes = Dit.Umb.ToolBox.Models.Constants.DocumentTypes;
using Link = Umbraco.Web.Models.Link;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class MutoboContentService : BaseService, IMutoboContentService
    {

        private readonly IImageService _imageService;
        private readonly ISliderService _sliderService;
        private readonly IConfigurationService _configurationService;


        public MutoboContentService(
            IImageService imageService,
            ISliderService sliderService,
            IConfigurationService configurationService)
        {
            _imageService = imageService;
            _sliderService = sliderService;
            _configurationService = configurationService;
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
                                    width: 900, imageCropMode: ImageCropMode.Max),
                                TeaserText = element.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText),
                                Link = element.Value<Umbraco.Web.Models.Link>(DocumentTypes.Flyer.Fields.Link)

                            });
                            break;

                        case DocumentTypes.Teaser.Alias:
                            result.Add(GetTeaser(element));
                            break;
                        case DocumentTypes.SliderComponent.Alias:
                            var sliderModule = new SliderComponent(element);

                            var useGoldenRatio = (sliderModule.Height == null && sliderModule.Width == null);


                            sliderModule.Slides = _sliderService.GetSlides(element,
                                DocumentTypes.SliderComponent.Fields.Slides, sliderModule.Width);
                            result.Add(sliderModule);
                            break;


             
                        case DocumentTypes.PictureModule.Alias:
                            var picModule = new PictureModule(element)
                            {
                                
                         
                            };
                            var isGoldenRatio = (picModule.Height == null && picModule.Width == null);
                            picModule.Image = element.HasValue(DocumentTypes.Picture.Fields.Image)
                                ? _imageService.GetImage(
                                    element.Value<IPublishedContent>(DocumentTypes.Picture.Fields.Image), 
                                    height: picModule.Height, 
                                    width: picModule.Width )
                                : null;
                            result.Add(picModule);
                            break;

                        case DocumentTypes.Newsletter.Alias:
                            result.Add(new Newsletter(element));
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

                teaser.Images = GetHighlightImages(article.Content);

                teaser.TeaserText = GetHighlightText(article.Content);
                teaser.TeaserTitle = GetHighlightTitle(article.Content);
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

        private IEnumerable<Image> GetHighlightImages(IPublishedContent content)
        {
            var result = new List<Image>();
            
                if (content.HasValue(ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.EmotionImages))
                    result.AddRange(_imageService.GetImages(content.Value<IEnumerable<IPublishedContent>>(ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.EmotionImages)));
        
            return result;
        }

        private string GetHighlightText(IPublishedContent content)
        {
            string result = null;

                if (content.HasValue(ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.Abstract))
                    result = content.Value<string>(ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.Abstract);
 

            return result;
        }

        private string GetHighlightTitle(IPublishedContent content)
        {
            string result = null;


                if (content.HasValue(ToolBox.Models.Constants.DocumentTypes.BasePage.Fields.PageTitle))
                    result = content.Value<string>(ToolBox.Models.Constants.DocumentTypes.BasePage.Fields.PageTitle);
       
            return result;
        }

    }
}
