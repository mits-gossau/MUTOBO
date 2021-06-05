using System.Collections.Generic;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
{
    public class BlogPageController : BasePageController
    {
        private readonly IImageService _imageService;

        public BlogPageController(IImageService imageService)
        {
            _imageService = imageService;
        }



        // GET: BlogPage
        public override ActionResult Index(ContentModel model)
        {
            return base.Index<BlogPage>(new BlogPage(model.Content)
            {
                EmotionImages = model.Content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages)
                    ? _imageService.GetImages(model.Content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages))
                    : new List<Image>(),
         

            });
        }
    }
}