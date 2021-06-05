using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ISliderService
    {
        IEnumerable<ISliderItem> GetSlides(IPublishedElement content, string fieldName, int? width = null,
            int? height = null, bool isGoldenRatio = false);
    }
}