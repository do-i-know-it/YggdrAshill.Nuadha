using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPullEventInputHandler :
        IHardwareHandler
    {
        IInputTerminal<Pulse> HasPulled { get; }

        IInputTerminal<Pulse> IsPulled { get; }

        IInputTerminal<Pulse> HasReleased { get; }

        IInputTerminal<Pulse> IsReleased { get; }
    }
}
