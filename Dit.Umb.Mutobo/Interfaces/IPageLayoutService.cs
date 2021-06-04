using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IPageLayoutService
    {
        IHeaderConfiguration GetHeaderConfiguration(IPublishedContent content = null);
        IFooterConfiguration GetFooterConfiguration(IPublishedContent content = null);

    }
}
