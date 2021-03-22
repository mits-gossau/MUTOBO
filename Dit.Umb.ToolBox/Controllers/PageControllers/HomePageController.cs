using System.Linq;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Services;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Web.Models;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Controllers.PageControllers
{
    public class HomePageController : BasePageController
    {
        private readonly IFlyerService _flyerService;
        private readonly ITeaserService _teaserService;


        public HomePageController(IFlyerService flyerService, ITeaserService teaserService)
        {
            Logger.Info<HomePageController>("HomePageController initialized");
            _flyerService = flyerService;
            _teaserService = teaserService;
        }


        public override ActionResult Index(ContentModel model)
        {

            var basepage = new BasePage(model.Content);


            return base.Index<HomePage>(new HomePage(model.Content)
            {
                FlyerList = _flyerService.GetFlyer(model.Content),
                TeaserList = _teaserService.GetTeaser(
                    model.Content.Children
                        .Where(c => c.ContentType.Alias == DocumentTypes.ArticlePage.Alias), 320,
                    cropMode: ImageCropMode.Max)
            });
        }
    }
}