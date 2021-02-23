using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface ISoftware<TDevice>
        where TDevice : IDevice
    {
        IDisconnection Connect(TDevice device);
    }
}
