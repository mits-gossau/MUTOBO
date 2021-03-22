using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Common.Extensions
{
    public static class ElementTypeExtensions
    {

        public static Image GetImage(this PublishedElementModel elementModel, string fieldName, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {
            var imageService = (IImageService) DependencyResolver.Current.GetService(typeof(IImageService));

            return imageService.GetImage(elementModel.Value<IPublishedContent>(fieldName), width, height,
                imageCropMode);
        }
    }
}
