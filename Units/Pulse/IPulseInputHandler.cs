using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulseInputHandler :
        IHardwareHandler
    {
        IConsumption<Pulse> HasEnabled { get; }

        IConsumption<Pulse> IsEnabled { get; }

        IConsumption<Pulse> HasDisabled { get; }

        IConsumption<Pulse> IsDisabled { get; }
    }
}
