using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Controllers.PageControllers;
using Dit.Umb.Mutobo.Interfaces;
using Sss.Waldlaeufer.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.Waldlaeufer.Controllers
{
    public class WoodContentPageController : ContentPageController
    {
        public WoodContentPageController(IMutoboContentService mutoboContentService, IImageService imageService) : base(mutoboContentService, imageService)
        {
        }


        public override ActionResult Index(ContentModel model)
        {
            return base.Index<WoodContentPage>(new WoodContentPage(model.Content)
            {
                EmotionImages = model.Content.HasValue(DocumentTypes.ArticlePage.Fields.EmotionImages) ?
                    ImageService.GetImages(model.Content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.ArticlePage.Fields.EmotionImages), width: 800, height:450, isGoldenRatio: true) :
                    null,
                Modules = MutoboContentService.GetContent(model.Content, DocumentTypes.HomePage.Fields.Modules)
            });
        }
    }
}
