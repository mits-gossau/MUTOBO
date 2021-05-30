using Dit.Umb.ToolBox.Models.Configuration;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface ISeoService
    {
        SeoConfiguration GetSeoConfiguration(IPublishedContent content);
    }
}