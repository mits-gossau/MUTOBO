using Dit.Umb.ToolBox.Models.PageModels;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IXmlSitemapServicecs
    {
        IEnumerable<BasePage> GetXmlSitemap(IPublishedContent model);
    }
}
