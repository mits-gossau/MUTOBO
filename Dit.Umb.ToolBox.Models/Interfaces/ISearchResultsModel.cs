using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.PoCo;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface ISearchResultsModel
    {
        string Term { get; set; }
        string Page { get; set; }
        IEnumerable<SearchResult> Results { get; set; }
    }
}