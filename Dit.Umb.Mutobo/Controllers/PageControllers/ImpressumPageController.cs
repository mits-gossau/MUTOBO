using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
{
    public class ImpressumPageController : BasePageController
    {
        private readonly IPageLayoutService _pageLayoutService;


        public ImpressumPageController(IPageLayoutService pageLayoutService)
        {
            _pageLayoutService = pageLayoutService;
        }


        // GET: ImpressumPage
        public override ActionResult Index(ContentModel model)
        {
            return base.Index<ImpressumPage>(new ImpressumPage(model.Content)
            {
            });
        }
    }
}