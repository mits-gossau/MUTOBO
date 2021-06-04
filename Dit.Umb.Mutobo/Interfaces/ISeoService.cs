using Dit.Umb.Mutobo.Configuration;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ISeoService
    {
        SeoConfiguration GetSeoConfiguration(IPublishedContent content);
    }
}