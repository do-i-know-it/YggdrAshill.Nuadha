using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITouchEventInputHandler :
        IHardwareHandler
    {
        IInputTerminal<Pulse> HasTouched { get; }

        IInputTerminal<Pulse> IsTouched { get; }

        IInputTerminal<Pulse> HasReleased { get; }

        IInputTerminal<Pulse> IsReleased { get; }
    }
}
