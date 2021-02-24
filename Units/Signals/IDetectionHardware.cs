using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IDetectionHardware :
        IHardware
    {
        IConnection<Pulse> HasEnabled { get; }

        IConnection<Pulse> IsEnabled { get; }

        IConnection<Pulse> HasDisabled { get; }

        IConnection<Pulse> IsDisabled { get; }
    }
}