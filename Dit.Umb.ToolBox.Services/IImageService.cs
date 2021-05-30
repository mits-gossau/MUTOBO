using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Services
{
    public interface IImageService
    {
        Image GetImage(IPublishedContent node, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture", bool isGoldenRatio = false);


        
        IEnumerable<Image> GetImages(IEnumerable<IPublishedContent> contentNodes, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture", bool isGoldenRatio = false);
    }
}
