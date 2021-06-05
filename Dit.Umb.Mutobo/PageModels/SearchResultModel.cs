using System.Collections.Generic;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.PageModels
{
    public class SearchResultModel : BasePage, ISearchResultsModel
    {
        public string Term { get; set; }
        public string Page { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }


        public SearchResultModel(IPublishedContent content) : base(content)
        {
        }
    }
}
