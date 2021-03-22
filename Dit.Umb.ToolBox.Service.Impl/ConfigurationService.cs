using System;
using Dit.Umb.ToolBox.Models.Configuration;
using Dit.Umb.ToolBox.Models.Constants;
using System.Configuration;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Current = Umbraco.Web.Composing.Current;
using System.Collections.Generic;
using System.Linq;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class ConfigurationService :  BaseService, IConfigurationService
    {
        public SeoConfiguration GetSeoConfiguration(IPublishedContent content)
        {

            return new SeoConfiguration
            {
                MetaTitle = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaTitle, content),
                MetaDescription = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaDescription, content),
                MetaKeywords = GetMetaDataValue(DocumentTypes.BasePage.Fields.MetaKeywords, content),
                ThumbNailWidth = 300,
                ThumbNailHeight = 300,
                ThumbnailUrl = content.GetImage(DocumentTypes.BasePage.Fields.Thumbnail, 300, 300, ImageCropMode.Crop)?
                    .DefaultSource?.Src ?? String.Empty
            };

        }

 





        private string GetMetaDataValue(string fieldName, IPublishedContent content)
        {
            var nodes = content.AncestorsOrSelf();

            foreach (var node in nodes)
            {
                var result = node.Value<string>(fieldName);

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return string.Empty;
        }




        public string GetAppSettingValue(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings[key];

            throw new AppSettingsException("Missing config/AppSettings.config or config entry");
        }

        public int? GetAppSettingIntValue(string key)
        {
            if (int.TryParse(ConfigurationManager.AppSettings[key], out var result))
                return result;

            throw new AppSettingsException("Missing config/AppSettings.config or config entry");
        }

        public bool? GetAppSettingBoolValue(string key)
        {
            if (bool.TryParse(ConfigurationManager.AppSettings[key], out var result))
                return result;

            throw new AppSettingsException("Missing config/AppSettings.config or config entry");
        }

    }
}
