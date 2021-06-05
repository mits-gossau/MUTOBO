using System.Collections.Generic;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IXmlSitemapServicecs
    {
        IEnumerable<BasePage> GetXmlSitemap(IPublishedContent model);
    }
}
