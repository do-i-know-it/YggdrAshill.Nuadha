using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IHardware<THardwareHandler>
        where THardwareHandler : IHardwareHandler
    {
        IDisconnection Connect(THardwareHandler handler);
    }
}
