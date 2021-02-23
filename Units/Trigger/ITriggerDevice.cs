using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDevice :
        IDevice
    {
        IConnection<Touch> Touch { get; }

        IConnection<Pull> Pull { get; }
    }
}
