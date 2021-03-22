using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IPictureLinkService
    {
        IEnumerable<PictureLink> GetPictureLinks(IEnumerable<IPublishedElement> elements);
    }
}