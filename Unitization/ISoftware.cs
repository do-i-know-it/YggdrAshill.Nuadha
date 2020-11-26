using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface ISoftware<TSoftwareHandler>
        where TSoftwareHandler : ISoftwareHandler
    {
        IDisconnection Connect(TSoftwareHandler handler);
    }
}
