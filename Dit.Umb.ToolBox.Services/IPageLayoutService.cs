
using Dit.Umb.ToolBox.Models.Configuration;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IPageLayoutService
    {
        IHeaderConfiguration GetHeaderConfiguration(IPublishedContent content = null);
        IFooterConfiguration GetFooterConfiguration(IPublishedContent content = null);

    }
}
