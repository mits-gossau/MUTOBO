using System;
using System.Collections.Generic;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Examine;
using Examine.Search;
using Serilog.Core;
using Umbraco.Web;
using SearchResult = Dit.Umb.ToolBox.Models.PoCo.SearchResult;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class SearchService : BaseService, ISearchService
    {

        private readonly IPageLayoutService _pageLayoutService;


        public SearchService(IPageLayoutService pageLayoutService)
        {
            _pageLayoutService = pageLayoutService;
        }



        public SearchResultModel PerformSearch(string term)
        {
            SearchResultModel result = null;
            try
            {
                // create the result object and assign the search term 
                result = new SearchResultModel(Helper.AssignedContentItem)
                {
                    HeaderConfiguration = _pageLayoutService.GetHeaderConfiguration(),
                    FooterConfiguration = _pageLayoutService.GetFooterConfiguration(),
                    Term = term
                };
            }
            catch(AppSettingsException e)
            {
                _logger.Error(this.GetType(), e, $"{AppConstants.LoggingPrefix} {e.Message}");
                throw e;
            }

            var pages = new List<SearchResult>();

            if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))
            {
                // Get the searcher object to perform the search
                var searcher = index.GetSearcher();

                var results = searcher.CreateQuery("content").Field("contents", term.MultipleCharacterWildcard())
                    .Or()
                    .Field("pageTitle", term.MultipleCharacterWildcard())
                    .Or()
                    .Field("mainContent", term.MultipleCharacterWildcard())
                    .Or()
                    .Field(DocumentTypes.ArticlePage.Fields.Abstract, term.MultipleCharacterWildcard())
                    .OrderByDescending(new SortableField("updateDate", SortType.Long))
                    .Execute();

                foreach (var res in results)
                {
                    var node = Helper.Content(res.Id);

                    pages.Add(new SearchResult()
                    {
                        Url = node.Url(),
                        Abstract = node.HasProperty(DocumentTypes.ArticlePage.Fields.Abstract) ? node.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract) : string.Empty,
                        Title = node.HasProperty(DocumentTypes.BasePage.Fields.PageTitle) ? node.Value<string>(DocumentTypes.BasePage.Fields.PageTitle) : string.Empty,
                        UrlTitle = node.Name
                    });

                }

                result.Results = pages;
                return result;
            }

            throw new SearchException("ExternalIndex is not present");
        }
    }
}
