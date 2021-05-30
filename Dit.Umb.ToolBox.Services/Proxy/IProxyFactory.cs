using System.Net;

namespace Dit.Umb.ToolBox.Services.Proxy
{
    public interface IProxyFactory
    {
        IWebProxy Create(IProxySettings settings);
    }
}
