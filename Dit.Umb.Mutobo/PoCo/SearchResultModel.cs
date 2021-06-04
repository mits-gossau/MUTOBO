using System.Collections.Generic;
using Dit.Umb.Mutobo.Interfaces;

namespace Dit.Umb.Mutobo.PoCo
{
    public class SearchResultModel : ISearchResultsModel
    {
        public string Term { get; set; }
        public string Page { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }
    }
}
