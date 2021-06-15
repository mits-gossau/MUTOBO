using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Mutobo.Common;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Modules;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Link = Umbraco.Web.Models.Link;

namespace Dit.Umb.Mutobo.Services
{
    public class FlyerService : BaseService, IFlyerService
    {

        private readonly IImageService _imageService;

        public FlyerService(IImageService imageService)
        {
            _imageService = imageService;
        }

     
        public IEnumerable<Flyer> GetFlyer(IPublishedContent node, bool firstPic = false)
        {
            var result = new List<Flyer>();
            var elements = node.HasValue(DocumentTypes.HomePage.Fields.Disturber) ? 
                node.Value<IEnumerable<IPublishedElement>>(DocumentTypes.HomePage.Fields.Disturber) : 
                new List<IPublishedElement>();
            
            foreach (IPublishedElement element in elements)
            {
                Flyer fly = new Flyer(element)
                {
                    
                };
                var link = element.Value<Link>(DocumentTypes.Flyer.Fields.Link);
                
                
                ArticlePage articel = null;

                //Get content from the linked ArtikelPage

                if (element.HasValue(DocumentTypes.Flyer.Fields.Link) && link.Udi != null)
                {
                    var content = Helper.Content(link.Udi);
                    articel = new ArticlePage(content)
                    {
                        //EmotionImages = content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages)
                        //    ? _imageService.GetImages(content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages), width: 500, imageCropMode: ImageCropMode.Max, nameSpace: "picture", isGoldenRatio: false) : null
                        EmotionImages = content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages)
                            ? content.GetImages(DocumentTypes.ArticlePage.Fields.EmotionImages,
                                    width: 500, imageCropMode: ImageCropMode.Max, useSources: true) : null
                    };
                }
                if (articel == null)
                {
                    fly.TeaserText = element.HasValue(DocumentTypes.Flyer.Fields.FlyerTeaserText) ? 
                        element.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText) : string.Empty;
                    fly.Image = element.GetImage(DocumentTypes.Flyer.Fields.FlyerImage, width: 900,  imageCropMode: ImageCropMode.Max, useSources: true);
                    //fly.Image = _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Flyer.Fields.FlyerImage), width: 500, imageCropMode: ImageCropMode.Max, nameSpace: "picture", isGoldenRatio:false);
                    fly.Link = element.HasValue(DocumentTypes.Flyer.Fields.FlyerLink) ? 
                        element.Value<Link>(DocumentTypes.Flyer.Fields.FlyerLink) : null;
                    Logger.Warn(this.GetType(), $"{AppConstants.LoggingPrefix} Keine ArtikelSeite auf dem Flyer verlinkt");
                }
                else //Check if flyer has the property or get it from the ArtikelPage
                {
                    fly.TeaserText = element.HasValue(DocumentTypes.Flyer.Fields.FlyerTeaserText)
                        ? element.Value<string>(DocumentTypes.Flyer.Fields.FlyerTeaserText)
                        : articel.Abstract;

                    //fly.Image = element.HasValue(DocumentTypes.Flyer.Fields.FlyerImage)
                    //    ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Flyer.Fields.FlyerImage), width: 500, imageCropMode: ImageCropMode.Max, nameSpace: "picture", isGoldenRatio: false)
                    //    : articel.EmotionImages.FirstOrDefault();

                    //TODO: SET PICTURE SOURCES
                    fly.Image = element.HasValue(DocumentTypes.Flyer.Fields.FlyerImage)
                        ? element.GetImage(DocumentTypes.Flyer.Fields.FlyerImage,
                            imageCropMode: ImageCropMode.Max, width: 900, useSources: true)
                        : articel.EmotionImages.FirstOrDefault();

                    fly.Link = element.HasValue(DocumentTypes.Flyer.Fields.FlyerLink)
                        ? element.Value<Link>(DocumentTypes.Flyer.Fields.FlyerLink)
                        : new Link() {Url = articel.Content.Url()};
                }

                // check if null and warn if so
                if (fly.TeaserText == null)
                    Logger.Warn(this.GetType(), $"{AppConstants.LoggingPrefix} Auf dem Flyer gibt es keinen Teaser Text");
                if (fly.Image == null)
                    Logger.Warn(this.GetType(), $"{AppConstants.LoggingPrefix} Auf dem Flyer gibt es kein Foto");
                if (fly.Link == null)
                    Logger.Warn(this.GetType(), $"{AppConstants.LoggingPrefix} Auf dem Flyer gibt es keinen Link");

                result.Add(fly);
            }

            return result;
        }
    }
}
