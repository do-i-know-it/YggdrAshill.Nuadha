using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickSoftwareHandler :
        IDevice,
        IButtonSoftwareHandler
    {
        IConnection<Tilt> Tilt { get; }
    }
}
