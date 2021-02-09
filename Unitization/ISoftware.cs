using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface ISoftware<TSoftwareHandler>
        where TSoftwareHandler : ISoftwareHandler
    {
        IDisconnection Connect(TSoftwareHandler handler);
    }
}
