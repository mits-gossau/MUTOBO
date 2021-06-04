using System.Collections.Generic;
using Dit.Umb.Mutobo.PoCo;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ISearchResultsModel
    {
        string Term { get; set; }
        string Page { get; set; }
        IEnumerable<SearchResult> Results { get; set; }
    }
}