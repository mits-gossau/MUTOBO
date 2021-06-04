using System;
using System.Configuration;
using Dit.Umb.Mutobo.Common.Exceptions;
using Dit.Umb.Mutobo.Interfaces;

namespace Dit.Umb.Mutobo.Services
{
    public class ConfigurationService :  BaseService, IConfigurationService
    {

        private string _keyWords = String.Empty;
        private ILoggingService _loggingService;

        public ConfigurationService(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }





        public string GetAppSettingValue(string key, bool essential = true)
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings[key];
            if (essential)
                throw new AppSettingsException("Missing config/AppSettings.config or config entry: " + key);

            _loggingService.Warn(this.GetType(), "Missing config/AppSettings.config or config entry: " + key);
            return String.Empty;
        }

        public int? GetAppSettingIntValue(string key, bool essential = true)
        {
            if (int.TryParse(ConfigurationManager.AppSettings[key], out var result))
                return result;
            if (essential)
                throw new AppSettingsException("Missing config/AppSettings.config or config entry: " + key);
            
            _loggingService.Warn(this.GetType(), "Missing config/AppSettings.config or config entry: " + key);
            return null;
        }

        public bool? GetAppSettingBoolValue(string key, bool essential = true)
        {
            if (bool.TryParse(ConfigurationManager.AppSettings[key], out var result))
                return result;
            if (essential)
                throw new AppSettingsException("Missing config/AppSettings.config or config entry: " + key);
            
            _loggingService.Warn(this.GetType(), "Missing config/AppSettings.config or config entry: " + key);
            return null;
        }
    }
}
