using System.Collections.Generic;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Link = Umbraco.Web.Models.Link;

namespace Dit.Umb.ToolBox.Common.Extensions
{
    public static class ContentExtensions
    {

        public static string GetDitUrl(this IPublishedContent content)
        {
            var redirectLink = content.Value<Link>(DocumentTypes.BasePage.Fields.RedirectLink)?.Url;

            if (string.IsNullOrEmpty(redirectLink))
                return content.Url();

            return redirectLink;
        }


        public static string GetLinkTarget(this IPublishedContent content)
        {


            var target = content.Value<Link>(DocumentTypes.BasePage.Fields.RedirectLink)?.Target;


            if (string.IsNullOrEmpty(target))
            {
                var ownPageFlag = content.Value<bool>(DocumentTypes.BasePage.Fields.OpenInNewWindow);
                return ownPageFlag ? "_blank" : "_self";
            }

            return target ?? "_self";

        }

        public static bool GetOpenInNewWindowFlag(this IPublishedContent content)
        {
            var target = content.Value<Link>(DocumentTypes.BasePage.Fields.RedirectLink)?.Target;


            if (string.IsNullOrEmpty(target))
            {
                var ownPageFlag = content.Value<bool>(DocumentTypes.BasePage.Fields.OpenInNewWindow);
                return ownPageFlag;
            }

            return target == "_blank";

        }



        public static Image GetImage(this IPublishedContent content, string field, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var imageService = (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            return content.HasValue(field)
                ? imageService.GetImage(content.Value<IPublishedContent>(field), width, height, imageCropMode)
                : null;
        }

        public static Image GetImage(this IPublishedElement element, string field, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var imageService = (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            return element.HasValue(field)
                ? imageService.GetImage(element.Value<IPublishedContent>(field), width, height, imageCropMode)
                : null;
        }


        public static IEnumerable<Image> GetImages(this IPublishedContent content, string field, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var imageService = (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            return content.HasValue(field)
                ? imageService.GetImages(content.Value<IEnumerable<IPublishedContent>>(field), width, height, imageCropMode)
                : null;
        }

        public static IEnumerable<Image> GetImages(this IPublishedElement element, string field, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var imageService = (IImageService)DependencyResolver.Current.GetService(typeof(IImageService));

            return element.HasValue(field)
                ? imageService.GetImages(element.Value<IEnumerable<IPublishedContent>>(field), width, height, imageCropMode)
                : null;
        }

    }
}