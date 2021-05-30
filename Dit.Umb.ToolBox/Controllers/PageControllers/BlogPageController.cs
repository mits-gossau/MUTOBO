using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Controllers.PageControllers
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