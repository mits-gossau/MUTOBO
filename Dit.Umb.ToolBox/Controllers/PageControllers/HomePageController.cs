using System.Linq;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Services;
using System.Web.Mvc;
using Dit.Umb.MKulturProzent.Classics.Models.Pages;
using Dit.Umb.Toolbox.Common.ContentExtensions;
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
        private readonly IMutoboContentService _contentService;


        public HomePageController(IFlyerService flyerService, ITeaserService teaserService, IMutoboContentService contentService)
        {
            Logger.Info<HomePageController>("HomePageController initialized");
            _flyerService = flyerService;
            _teaserService = teaserService;
            _contentService = contentService;
        }


        public override ActionResult Index(ContentModel model)
        {
            var basepage = new BasePage(model.Content);


            return base.Index<HomePage>(new HomePage(model.Content)
            {
                Modules = _contentService.GetContent(model.Content, "modules")
            });
        }
    }
}