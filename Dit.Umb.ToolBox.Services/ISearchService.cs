using Dit.Umb.ToolBox.Models.PageModels;

namespace Dit.Umb.ToolBox.Services
{
    public interface ISearchService
    {
        SearchResultModel PerformSearch(string term);
    }
}