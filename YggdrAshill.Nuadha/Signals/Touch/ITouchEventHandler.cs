using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
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
