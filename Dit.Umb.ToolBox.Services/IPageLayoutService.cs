
using Dit.Umb.ToolBox.Models.Configuration;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IPageLayoutService
    {
        HeaderConfiguration GetHeaderConfiguration(IPublishedContent content = null);
        FooterConfiguration GetFooterConfiguration(IPublishedContent content = null);

    }
}
