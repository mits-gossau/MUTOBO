using Dit.Umb.ToolBox.Services.Proxy;

namespace Dit.Umb.ToolBox.Services.Impl.Proxy
{
    public class ProxySettings : IProxySettings
    {
        public ProxySettings(IConfigurationService settings)
        {
            IsEnabled = settings.GetAppSettingBoolValue("Classics.ProxyEnabled") ?? false;
            Server = settings.GetAppSettingValue("Classics.ProxyServer");
            Password = settings.GetAppSettingValue("Classics.ProxyPassword");
            Username = settings.GetAppSettingValue("Classics.ProxyUsername");
            Port = (int)settings.GetAppSettingIntValue("Classics.ProxyPort");
            Domain = settings.GetAppSettingValue("Classics.Domain");
        }

        public bool IsEnabled { get; }
        public string Server { get; }
        public string Domain { get; }
        public string Username { get; }
        public string Password { get; }
        public int Port { get; }
    }
}
