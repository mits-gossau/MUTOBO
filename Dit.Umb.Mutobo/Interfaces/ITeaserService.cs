using System.Collections.Generic;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ITeaserService
    {
        IEnumerable<ArticlePage> GetTeaser(IEnumerable<IPublishedContent> content, int? width = null, int? height = null, ImageCropMode cropMode = ImageCropMode.Crop);
    }
}