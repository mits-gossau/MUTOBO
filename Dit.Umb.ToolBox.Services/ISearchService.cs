using Dit.Umb.ToolBox.Models.PageModels;
using Examine;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface ISearchService
    {
        SearchResultModel PerformSearch(string term);


        //may params into SearchSettingsModel
        IEnumerable<ISearchResult> GetPageOfSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10);

        IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10);
    }
}