using Dit.Umb.ToolBox.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IConfigurationService
    {
        SeoConfiguration GetSeoConfiguration(IPublishedContent content);


        string GetAppSettingValue(string key);
        int? GetAppSettingIntValue(string key);
        bool? GetAppSettingBoolValue(string key);

    }
}
