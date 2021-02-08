using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IInputDevice<THardwareHandler> :
        IHardware<THardwareHandler>,
        IDisconnection,
        IIgnition
        where THardwareHandler : IHardwareHandler
    {

    }
}
