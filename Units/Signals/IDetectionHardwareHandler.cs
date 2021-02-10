using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IDetectionHardwareHandler :
        IHardwareHandler
    {
        IConsumption<Pulse> HasEnabled { get; }

        IConsumption<Pulse> IsEnabled { get; }

        IConsumption<Pulse> HasDisabled { get; }

        IConsumption<Pulse> IsDisabled { get; }
    }
}
