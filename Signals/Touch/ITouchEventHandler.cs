using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITouchEventHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasTouched { get; }

        IOutputTerminal<Pulse> IsTouched { get; }

        IOutputTerminal<Pulse> HasReleased { get; }

        IOutputTerminal<Pulse> IsReleased { get; }
    }
}
