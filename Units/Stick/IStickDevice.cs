using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDevice :
        IDevice
    {
        IConnection<Touch> Touch { get; }

        IConnection<Tilt> Tilt { get; }
    }
}
