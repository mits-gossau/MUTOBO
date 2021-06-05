using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IFormPageService
    {
        FormPage GetFormPageModel(IPublishedContent content);
    }
}
