using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class SearchResultModel : BasePage
    {
        public string Term { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }


        public SearchResultModel(IPublishedContent content) : base(content)
        {
        }
    }
}
