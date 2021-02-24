using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IDevice<TSoftware>
        where TSoftware : ISoftware
    {
        IDisconnection Connect(TSoftware software);
    }
}
