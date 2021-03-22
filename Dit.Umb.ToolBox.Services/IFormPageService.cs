using Dit.Umb.ToolBox.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IFormPageService
    {
        FormPage GetFormPageModel(IPublishedContent content);
    }
}
