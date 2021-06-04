using System.Collections.Generic;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
{
    public class TeaserPageController : ArticlePageController
    {
        private readonly ITeaserService _teaserService;

        public TeaserPageController(IImageService imageService, ITeaserService teaserService) : base(imageService)
        {
            _teaserService = teaserService;
        }

        public override ActionResult Index(ContentModel model)
        {
            var customModel = new TeaserPage(model.Content);
            customModel.Teasers =
                _teaserService.GetTeaser(
                    model.Content.Value<IEnumerable<IPublishedContent>>(DocumentTypes.TeaserPage.Fields.Teasers));
            return base.Index<TeaserPage>(customModel);
        }
    }
}