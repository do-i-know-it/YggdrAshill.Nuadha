using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
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
