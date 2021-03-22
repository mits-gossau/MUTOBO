using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Controllers.PageControllers
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