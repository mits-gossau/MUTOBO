using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Interfaces;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface ISliderService
    {
        IEnumerable<ISliderItem> GetSlides(IPublishedElement content, string fieldName, int? width = null,
            int? height = null, bool isGoldenRatio = false);
    }
}