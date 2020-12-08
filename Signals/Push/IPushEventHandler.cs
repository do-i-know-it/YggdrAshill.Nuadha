using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPushEventHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasPushed { get; }

        IOutputTerminal<Pulse> IsPushed { get; }

        IOutputTerminal<Pulse> HasReleased { get; }

        IOutputTerminal<Pulse> IsReleased { get; }
    }
}
