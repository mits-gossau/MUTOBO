using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class SearchResultModel : ISearchResultsModel
    {
        public string Term { get; set; }
        public string Page { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }
    }
}
