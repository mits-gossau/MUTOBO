using System;
using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Mutobo.Common;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Modules;
using Dit.Umb.Mutobo.PageModels;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using DocumentTypes = Dit.Umb.Mutobo.Constants.DocumentTypes;

namespace Dit.Umb.Mutobo.Services
{
    public class MutoboContentService : BaseService, IMutoboContentService
    {

        protected readonly IImageService ImageService;
        protected readonly ISliderService SliderService;
        protected readonly IConfigurationService ConfigurationService;
        private readonly ICardService _cardService;


        public MutoboContentService(
            IImageService imageService,
            ISliderService sliderService,
            IConfigurationService configurationService,
            ICardService cardService)
        {
            _cardService = cardService;
            ImageService = imageService;
            SliderService = sliderService;
            ConfigurationService = configurationService;
        }


        public virtual IEnumerable<MutoboContentModule> GetContent(IPublishedContent content, string fieldName)
        {


            if (content.HasValue(fieldName))
            {
                var result = new List<MutoboContentModule>();

                var elements =
                    content.Value<IEnumerable<IPublishedElement>>(fieldName);

                foreach (var element in elements.Select((value, index) => new {index, value}))
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
                        case DocumentTypes.Flyer.Alias:
                            result.Add(new Flyer(element.value)
                            {
                                SortOrder = element.index,
                                Image = element.value.GetImage(DocumentTypes.Flyer.Fields.FlyerImage,
                                    width: 900, imageCropMode: ImageCropMode.Max),
                                TeaserText = element.value.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText),
                                Link = element.value.Value<Umbraco.Web.Models.Link>(DocumentTypes.Flyer.Fields.Link)

                            });
                            break;

                        case DocumentTypes.Teaser.Alias:
                            result.Add(GetTeaser(element.value, element.index));
                            break;
                        case DocumentTypes.SliderComponent.Alias:
                            var sliderModule = new SliderComponent(element.value)
                            {
                                SortOrder = element.index
                            };

                            var useGoldenRatio = (sliderModule.Height == null && sliderModule.Width == null);


                            sliderModule.Slides = SliderService.GetSlides(element.value,
                                DocumentTypes.SliderComponent.Fields.Slides, sliderModule.Width);
                            result.Add(sliderModule);
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
                                    width: picModule.Width )
                                : null;
                            result.Add(picModule);
                            break;

                        case DocumentTypes.Newsletter.Alias:
                            result.Add(new Newsletter(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.BlogModule.Alias:
                            result.Add(new BlogModule(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.Accordeon.Alias:
                            result.Add(new Accordeon(element.value)
                            {
                                SortOrder   = element.index
                            });
                            break;
                        case DocumentTypes.Quote.Alias:
                            result.Add(new Quote(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.CardContainer.Alias:
                            result.Add(new CardContainer(element.value)
                            {
                                Cards = _cardService.GetCards(element.value, Constants.DocumentTypes.CardContainer.Fields.Cards),
                                // set the sort order of the module to ensure the module order
                                SortOrder = element.index
                            });
                            break;
                    }
                }

                return result;
            }

            return null;
        }


        private Teaser GetTeaser(IPublishedElement element, int index)
        {

            var teaser = new Teaser(element)
            {
                SortOrder = index
            };


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
                    ? ImageService.GetImages(
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
            
                if (content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages))
                    result.AddRange(ImageService.GetImages(content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages)));
        
            return result;
        }

        private string GetHighlightText(IPublishedContent content)
        {
            string result = null;

                if (content.HasValue(DocumentTypes.ArticlePage.Fields.Abstract))
                    result = content.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract);
 

            return result;
        }

        private string GetHighlightTitle(IPublishedContent content)
        {
            string result = null;


                if (content.HasValue(DocumentTypes.BasePage.Fields.PageTitle))
                    result = content.Value<string>(DocumentTypes.BasePage.Fields.PageTitle);
       
            return result;
        }

    }
}
