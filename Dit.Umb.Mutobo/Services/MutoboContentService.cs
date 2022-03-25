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
    public class MutoboContentService : BaseService, IMutoboContentService
    {

        protected readonly IImageService ImageService;
        protected readonly ISliderService SliderService;
        protected readonly IConfigurationService ConfigurationService;
        private readonly ICardService _cardService;
        private readonly IImageHotspotService _imageHotspotService;
        private readonly IMutoboSimpleContentService _mutoboSimpleContentService;
        private readonly ISliderTabService _sliderTabService;


        public MutoboContentService(
            IImageService imageService,
            ISliderService sliderService,
            IConfigurationService configurationService,
            ICardService cardService,
            IImageHotspotService imageHotspotService,
            IMutoboSimpleContentService mutoboSimpleContentService,
            ISliderTabService sliderTabService)
        {
            _cardService = cardService;
            ImageService = imageService;
            SliderService = sliderService;
            ConfigurationService = configurationService;
            _imageHotspotService = imageHotspotService;
            _mutoboSimpleContentService = mutoboSimpleContentService;
            _sliderTabService = sliderTabService;
        }


        public virtual IEnumerable<MutoboContentModule> GetContent(IPublishedContent content, string fieldName)
        {


            if (content.HasValue(fieldName))
            {
                var result = new List<MutoboContentModule>();

                var elements =
                    content.Value<IEnumerable<IPublishedElement>>(fieldName);

                result.AddRange(_mutoboSimpleContentService.GetSimpleContent(content, fieldName));

                foreach (var element in elements.Select((value, index) => new {index, value}))
                {
                    switch (element.value.ContentType.Alias)
                    {
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
                        case DocumentTypes.Newsletter.Alias:
                            result.Add(new Newsletter(element.value)
                            {
                                SortOrder = element.index
                            });
                            break;
                        case DocumentTypes.TwoColumnContainer.Alias:
                        case DocumentTypes.ThreeColumnContainer.Alias:
                        case DocumentTypes.FourColumnContainer.Alias:

                            IEnumerable<IPublishedElement> Elements =
                                element.value.HasValue(DocumentTypes.TwoColumnContainer.Fields.Elements)
                                    ? element.value
                                        .Value<IEnumerable<IPublishedElement>>(DocumentTypes.TwoColumnContainer.Fields
                                            .Elements)
                                        .ToList()
                                    : new List<IPublishedElement>();

                            List<IPublishedElement> ResultElements = new List<IPublishedElement>();

                            if (Elements.Any())
                                Elements.ForEach(e =>
                                {
                                    if (e.ContentType.Alias == DocumentTypes.PictureModule.Alias)
                                    {
                                        var img = ImageService.GetImage(e.Value<IPublishedContent>(DocumentTypes.PictureModule.Fields.Image));
                                        PictureModule pictureModule = new PictureModule(e)
                                        {
                                            Image = img
                                        };
                                        ResultElements.Add(pictureModule);
                                    }
                                    else if (e.ContentType.Alias == DocumentTypes.PictureLink.Alias)
                                    {
                                        var img = ImageService.GetImage(e.Value<IPublishedContent>(DocumentTypes.PictureLink.Fields.Image));
                                        PictureLink pictureLink = new PictureLink(e)
                                        {
                                            Image = img
                                        };
                                        ResultElements.Add(pictureLink);
                                    }
                                    else
                                    {
                                        ResultElements.Add(e);
                                    }
                                });

                            if (element.value.ContentType.Alias == DocumentTypes.TwoColumnContainer.Alias)
                            {
                                result.Add(new TwoColumnContainer(element.value)
                                {
                                    Elements = ResultElements,
                                    SortOrder = element.index
                                });
                            } else if (element.value.ContentType.Alias == DocumentTypes.ThreeColumnContainer.Alias)
                            {
                                result.Add(new ThreeColumnContainer(element.value)
                                {
                                    Elements = ResultElements,
                                    SortOrder = element.index
                                });
                            } else if (element.value.ContentType.Alias == DocumentTypes.FourColumnContainer.Alias)
                            {
                                result.Add(new FourColumnContainer(element.value)
                                {
                                    Elements = ResultElements,
                                    SortOrder = element.index
                                });
                            }
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
                        case DocumentTypes.ImageMitHotspot.Alias:
                            result.Add(new ImageMitHotspots(element.value)
                            {
                                SortOrder = element.index,
                                Image = element.value.HasValue(DocumentTypes.ImageMitHotspot.Fields.Image)
                                ? ImageService.GetImage(element.value.Value<IPublishedContent>(DocumentTypes.ImageMitHotspot.Fields.Image))
                                : null,
                                Hotspots = _imageHotspotService.GetImageHotspotContainers(element.value, DocumentTypes.ImageMitHotspot.Fields.Hotspots)
                            });
                            break;
                        case DocumentTypes.SliderMitTabs.Alias:
                            result.Add(new SliderMitTabs(element.value)
                            {
                                SortOrder = element.index,
                                Tabs = _sliderTabService.GetTabs(element.value, DocumentTypes.SliderMitTabs.Fields.Tabs),
                                BackgroundImg = ImageService.GetImage(element.value.Value<IPublishedContent>(DocumentTypes.SliderMitTabs.Fields.BackgroundImg))
                            });
                            break;
                    }
                }

                return result.OrderBy(e => e.SortOrder);
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
