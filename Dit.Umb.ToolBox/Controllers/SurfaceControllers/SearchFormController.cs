using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using System.Collections.Specialized;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class SearchFormController : SurfaceController
    {
        private readonly ISearchService _searchService;


        public SearchFormController(ISearchService searchService, IConfigurationService configurationService)
        {
            _searchService = searchService;

        }

        // GET: SearchForm
        public ActionResult Index()
        {
            return View("~/Views/Partials/SearchForm.cshtml", new SearchFormModel() { });
        }


        [HttpPost]
        public ActionResult PostData(SearchFormModel model)
        {
            if (String.IsNullOrEmpty(model.Page))
                model.Page = Request?.Url?.ToString() ?? string.Empty;

            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var queryString = new NameValueCollection();
            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                queryString.Add("searchTerm", model.SearchTerm);
            }

            if (!string.IsNullOrWhiteSpace(model.Page))
            {
                queryString.Add("page", model.Page);
            }

            return PartialView("~/Views/Partials/SearchResults.cshtml", new Dit.Umb.ToolBox.Models.PoCo.SearchResultModel()
            {
                Results = _searchService.PerformSearch(model.SearchTerm).Results,
                Term = model.SearchTerm
            });
        }

        [HttpPost]
        public ActionResult PostDataClassics(SearchFormModel model)
        {
            return PartialView("~/Views/Partials/SearchResults.cshtml", new Dit.Umb.ToolBox.Models.PoCo.SearchResultModel()
            {
                Results = _searchService.PerformSearch(model.SearchTerm).Results,
                Term = model.SearchTerm
            });
        }



    }
}