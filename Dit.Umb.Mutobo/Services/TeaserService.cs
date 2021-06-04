using System.Collections.Generic;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Services
{
    public class TeaserService : BaseService, ITeaserService
    {

        private readonly IImageService _imageService;


        public TeaserService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IEnumerable<ArticlePage> GetTeaser(IEnumerable<IPublishedContent> content,  int? width = null, int? height = null, ImageCropMode cropMode = ImageCropMode.Crop)
        {
            var result = new List<ArticlePage>();

            if (content != null)
            {
                foreach (var c in content)
                {
                    result.Add(new ArticlePage(c)
                    {
                        EmotionImages = c.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                            _imageService.GetImages(c.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages), width, 
                                height, cropMode) :
                            new List<Image>()
                    });
                }

            }

            return result;
        }
    }
}
