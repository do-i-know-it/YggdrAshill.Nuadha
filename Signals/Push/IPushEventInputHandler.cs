using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPushEventInputHandler :
        IHardwareHandler
    {
        IInputTerminal<Pulse> HasPushed { get; }

        IInputTerminal<Pulse> IsPushed { get; }

        IInputTerminal<Pulse> HasReleased { get; }

        IInputTerminal<Pulse> IsReleased { get; }
    }
}
