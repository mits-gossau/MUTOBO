namespace Dit.Umb.ToolBox.Services.Proxy
{
    public interface IProxySettings
    {
        bool IsEnabled { get; }
        string Server { get; }
        string Domain { get; }
        string Username { get; }
        string Password { get; }
        int Port { get; }
    }
}
