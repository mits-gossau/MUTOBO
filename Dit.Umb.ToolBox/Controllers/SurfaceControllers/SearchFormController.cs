using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web.Mvc;

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
            return View("~/Views/Partials/SearchForm.cshtml", new SearchFormModel(){});
        }


        [HttpPost]
        public ActionResult PostData(SearchFormModel model)
        {
            return View("~/Views/WCSearchResultsPage.cshtml", _searchService.PerformSearch(model.SearchTerm));
        }
    }
}