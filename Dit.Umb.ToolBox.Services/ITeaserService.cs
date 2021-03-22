using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Services
{
    public interface ITeaserService
    {
        IEnumerable<ArticlePage> GetTeaser(IEnumerable<IPublishedContent> content, int? width = null, int? height = null, ImageCropMode cropMode = ImageCropMode.Crop);
    }
}