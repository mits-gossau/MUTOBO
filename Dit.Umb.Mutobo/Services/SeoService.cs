using System;
using System.Linq;
using Dit.Umb.Mutobo.Common;
using Dit.Umb.Mutobo.Configuration;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Services
{
    public class SeoService : ISeoService
    {
        public SeoConfiguration GetSeoConfiguration(IPublishedContent content)
        {
            var keywords = string.Empty;

            keywords =  GetKeyWords();



            return new SeoConfiguration
            {
                MetaTitle = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaTitle, content),
                MetaDescription = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaDescription, content),
                MetaKeywords = keywords,
                ThumbNailWidth = 300,
                ThumbNailHeight = 300,
                ThumbnailUrl = content.GetImage(DocumentTypes.BasePage.Fields.Thumbnail, 300, 300, ImageCropMode.Crop)?
                    .DefaultSource?.Src ?? String.Empty
            };

        }



        private string GetAbstract()
        {
            var result = string.Empty;
            return result;
        }

        private string GetKeyWords()
        {
            string result = String.Empty;




            var allKeywords = Current.UmbracoHelper.AssignedContentItem
                .AncestorsOrSelf()
                .ToList()
                .FirstOrDefault(c => c.ContentType.Alias == DocumentTypes.HomePage.Alias)
                ?.DescendantsOrSelf()
                .ToList()
                .Where(c =>
                    c.HasProperty(DocumentTypes.BasePage.Fields.MetaKeywords) &&
                    c.HasValue(DocumentTypes.BasePage.Fields.MetaKeywords));






            if (allKeywords != null)
                foreach (var keyWords in allKeywords)
                {
                    var value = keyWords.Value<string>(DocumentTypes.BasePage.Fields.MetaKeywords);
                    if (value.EndsWith(","))
                        result += value.TrimEnd() + " ";
                    else
                    {
                        result += $"{value}, ";
                    }
                }

            return result?.TrimEnd().TrimEnd(',');
        }


        private string GetMetaDataValue(string fieldName, IPublishedContent content)
        {
            var nodes = content.AncestorsOrSelf();

            foreach (var node in nodes)
            {
                var result = node.Value<string>(fieldName);




                if (fieldName == DocumentTypes.BasePage.Fields.MetaDescription && string.IsNullOrEmpty(result))
                {
                    result = node.HasProperty(DocumentTypes.ArticlePage.Fields.Abstract) &&
                             node.HasValue(DocumentTypes.ArticlePage.Fields.Abstract)
                        ? node.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract)
                        : string.Empty;
                }

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return string.Empty;
        }
    }
}
