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
using Umbraco.Web.Models;

namespace Sss.Waldlaeufer.Controllers
{
    public class WoodHomePageController : HomePageController
    {
        public WoodHomePageController(IMutoboContentService contentService) : base(contentService)
        {
        }

        public override ActionResult Index(ContentModel model)
        {
            return base.Index<WoodHomePage>(new WoodHomePage(model.Content)
            {
                Modules = ContentService.GetContent(model.Content, DocumentTypes.ContentPage.Fields.Modules)
            });
        }
    }
}
