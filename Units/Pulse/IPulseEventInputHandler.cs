using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulseEventInputHandler :
        IHardwareHandler
    {
        IInputTerminal<Pulse> HasEnabled { get; }

        IInputTerminal<Pulse> IsEnabled { get; }

        IInputTerminal<Pulse> HasDisabled { get; }

        IInputTerminal<Pulse> IsDisabled { get; }
    }
}
