using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPullEventHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasPulled { get; }

        IOutputTerminal<Pulse> IsPulled { get; }

        IOutputTerminal<Pulse> HasReleased { get; }

        IOutputTerminal<Pulse> IsReleased { get; }
    }
}
