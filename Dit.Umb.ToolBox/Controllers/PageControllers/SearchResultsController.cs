using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using SearchResultModel = Dit.Umb.ToolBox.Models.PageModels.SearchResultModel;

namespace Dit.Umb.ToolBox.Controllers.PageControllers
{
    public class SearchResultsController : BasePageController
    {


        // GET: ArticlePage
        public override ActionResult Index(ContentModel model)
        {
            return base.Index<SearchResultModel>(new SearchResultModel(model.Content)
            {

            });
            //return View("~/Views/Partials/SearchForm.cshtml", new SearchFormModel() { });
        }
    }
}