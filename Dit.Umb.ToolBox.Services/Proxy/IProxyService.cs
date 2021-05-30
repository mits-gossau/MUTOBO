using System.Net;

namespace Dit.Umb.ToolBox.Services.Proxy
{
    public interface IProxyService
    {
        bool IsEnabled();
        IWebProxy GetProxy();
    }
}
