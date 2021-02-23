using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IHardware<THardwareHandler>
        where THardwareHandler : IHardwareHandler
    {
        IDisconnection Connect(THardwareHandler handler);
    }
}
