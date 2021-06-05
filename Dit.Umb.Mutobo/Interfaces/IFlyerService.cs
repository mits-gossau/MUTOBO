using System.Collections.Generic;
using Dit.Umb.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IFlyerService
    {
        IEnumerable<Flyer> GetFlyer(IPublishedContent node, bool firstPic = false);
    }
}
