using System;
using Dit.Umb.ToolBox.Models.PoCo;
using System.Collections.Generic;
using System.Linq;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.Enum;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class ImageService : BaseService, IImageService
    {
        public Image GetImage(IPublishedContent node, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture")
        
        {

            if (node == null)
            {
                return null;
            }

            var media = Helper.Media(node.Id);

            if (media == null)
                throw new ImageException("Node is null or no Media with this Node found");

            return new Image()
            {
                Sources = GetImageSources(media, width, height, imageCropMode),
                Alt = media.Name,
                Height = height.HasValue ? $"{height}px" : null,
                Width = width.HasValue ? $"{width}px" : null,
                Namespace = nameSpace,
                ImageNode = node
            };
        }


        private IEnumerable<ImageSource> GetImageSources(IPublishedContent media, int? width = null, int? height= null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var result = new List<ImageSource>();
            var dimensions = Enum.GetValues(typeof(EImageDimension)).Cast<EImageDimension>();

            foreach (var dimension in dimensions)
            {
                int? calculatedWidth;
                int? calculatedHeight;

                switch (dimension)
                {
                    case EImageDimension.Small:
                        calculatedHeight = height.HasValue ? (int?)(height.Value * 0.2) : null;
                        calculatedWidth = width.HasValue ? (int?) (width.Value * 0.2) : height.HasValue ? null : (int?)600;
                        break;
                    case EImageDimension.Medium:
                        calculatedHeight = height.HasValue ? (int?)(height.Value * 0.5) : null;
                        calculatedWidth = width.HasValue ? (int?)(width.Value * 0.5) : height.HasValue ? null : (int?)985;
                        break;
                    case EImageDimension.Large:
                        calculatedHeight = height.HasValue ? (int?)(height.Value * 1.2) : null;
                        calculatedWidth = width.HasValue ? (int?)(width.Value * 1.2) : height.HasValue ? null : (int?)1150;
                        break;
                    case EImageDimension.ExtraLarge:
                        calculatedHeight = height.HasValue ? (int?)(height.Value * 1.5) : null;
                        calculatedWidth = width.HasValue ? (int?)(width.Value * 1.5) : height.HasValue ? null : (int?)1600;
                        break;
                    default:
                        calculatedHeight = height;
                        calculatedWidth = width;
                        break;

                }



                //var mimeType = media.HasProperty("umbracoExtension") && media.HasValue("umbracoExtension")
                //    ? $"image/{media.Value<string>("umbracoExtension")}".Replace("jpg", "jpeg")
                //    : string.Empty;

                result.Add(new ImageSource()
                {
                    Size = dimension,
                    Src = media.GetCropUrl(width: calculatedWidth, height: calculatedHeight, imageCropMode: imageCropMode, furtherOptions: "&format=webp&quality=80"),
                    Type = "image/webp" 
                });   
            }

            return result;

        }

        public IEnumerable<Image> GetImages(IEnumerable<IPublishedContent> contentNodes, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture")
        {
            return contentNodes?.Select(n => new Image()
            {
                Sources = GetImageSources(n,  width, height, imageCropMode),
                Alt = n.Name,
                Height = height.HasValue ? $"{height}px" : null,
                Width = width.HasValue ? $"{width}px" : null,
                Namespace = nameSpace,
                ImageNode = n
            }) ?? new List<Image>();
        }

    }
}
