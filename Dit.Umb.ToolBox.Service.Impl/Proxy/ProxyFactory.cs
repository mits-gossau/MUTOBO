using Dit.Umb.ToolBox.Services.Proxy;
using System;
using System.Net;

namespace Dit.Umb.ToolBox.Services.Impl.Proxy
{
    public class ProxyFactory : IProxyFactory
    {
        public IWebProxy Create(IProxySettings settings)
        {
            return new WebProxy
            {
                Address = new Uri(settings.Server + ":" + settings.Port),
                Credentials = new NetworkCredential
                {
                    Domain = settings.Domain,
                    UserName = settings.Username,
                    Password = settings.Password
                }
            };
        }
    }
}
