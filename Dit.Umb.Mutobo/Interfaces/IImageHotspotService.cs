using Dit.Umb.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IImageHotspotService
    {
        IEnumerable<ImageHotspotContainer> GetImageHotspotContainers(IPublishedElement content, string fieldName);
    }
}
