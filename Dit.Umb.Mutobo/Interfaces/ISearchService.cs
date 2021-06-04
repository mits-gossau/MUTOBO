using System.Collections.Generic;
using Dit.Umb.Mutobo.PageModels;
using Examine;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ISearchService
    {
        SearchResultModel PerformSearch(string term);


        //may params into SearchSettingsModel
        IEnumerable<ISearchResult> GetPageOfSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10);

        IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10);
    }
}