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
        string GetAppSettingValue(string key, bool essential = true);
        int? GetAppSettingIntValue(string key, bool essential = true);
        bool? GetAppSettingBoolValue(string key, bool essential = true);
    }
}
