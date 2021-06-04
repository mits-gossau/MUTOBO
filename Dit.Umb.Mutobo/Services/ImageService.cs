using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dit.Umb.Mutobo.Common.Exceptions;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Services
{
    public class ImageService : BaseService, IImageService
    {
        public Image GetImage(IPublishedContent node, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture", bool isGoldenRatio = false)

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
                ImageNode = node,
                IsGoldenRatio = isGoldenRatio
            };
        }


        private IEnumerable<ImageSource> GetImageSources(IPublishedContent media, int? width = null, int? height= null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var result = new List<ImageSource>();
            
            var dimensions = System.Enum.GetValues(typeof(EImageDimension)).Cast<EImageDimension>();

            foreach (var dimension in dimensions)
            {
                int? calculatedWidth;
                int? calculatedHeight;

                switch (dimension)
                {
                    // 400px
                    case EImageDimension.Small:
                        calculatedHeight = (int?)(height * 0.45);
                        calculatedWidth = (int?)(width * 0.45);
                        break;
                    // 600px;
                    case EImageDimension.Medium:
                        calculatedHeight = (int?)(height * 0.67);
                        calculatedWidth = (int?)(width * 0.67);
                        break;
                    // 1200px
                    case EImageDimension.Large:
                        calculatedHeight = (int?)(height * 1.34);
                        calculatedWidth = (int?)(width * 1.34);
                        break;
                    // 2250px
                    case EImageDimension.ExtraLarge:
                        calculatedHeight = (int?)(height * 2.5);
                        calculatedWidth = (int?)(width * 2.5);
                        break;
                    default:
                        result.Add(new ImageSource()
                        {
                            Size = EImageDimension.Default,
                            Type = "image/png",
                            Src = HttpUtility.HtmlDecode(media.GetCropUrl(width, height, imageCropMode: imageCropMode, furtherOptions: "&format=png&quality=80"))  
                        });
                        calculatedHeight = height;
                        calculatedWidth = width;
                        break;

                }

                result.Add(new ImageSource()
                {
                    Size = dimension,
                    Src = HttpUtility.HtmlDecode(media.GetCropUrl(width: calculatedWidth, height: calculatedHeight, imageCropMode: imageCropMode, furtherOptions: "&format=webp&quality=80")) ,
                    Type = "image/webp" 
                });   
            }

            return result;

        }

        public IEnumerable<Image> GetImages(IEnumerable<IPublishedContent> contentNodes, int? width = null, int? height = null,
            ImageCropMode imageCropMode = ImageCropMode.Crop, string nameSpace = "picture", bool isGoldenRatio = false)
        {
            return contentNodes?.Select(n => new Image()
            {
                Sources = GetImageSources(n,  width, height, imageCropMode),
                Alt = n.Name,
                Height = height.HasValue ? $"{height}px" : null,
                Width = width.HasValue ? $"{width}px" : null,
                Namespace = nameSpace,
                ImageNode = n,
                IsGoldenRatio = isGoldenRatio
            }) ?? new List<Image>();
        }

    }
}
