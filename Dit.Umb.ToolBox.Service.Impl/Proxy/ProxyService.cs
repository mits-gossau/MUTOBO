using Dit.Umb.ToolBox.Services.Proxy;
using System.Net;

namespace Dit.Umb.ToolBox.Services.Impl.Proxy
{
    public class ProxyService : IProxyService
    {
        private readonly IProxySettings _proxySettings;
        private readonly IProxyFactory _proxyFactory;

        public ProxyService(IProxySettings proxySettings, IProxyFactory proxyFactory)
        {
            _proxySettings = proxySettings;
            _proxyFactory = proxyFactory;
        }
        public bool IsEnabled()
        {
            return _proxySettings.IsEnabled;
        }

        public IWebProxy GetProxy()
        {
            return _proxyFactory.Create(_proxySettings);
        }

 
    }
}
