using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPullEventOutputHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasPulled { get; }

        IOutputTerminal<Pulse> IsPulled { get; }

        IOutputTerminal<Pulse> HasReleased { get; }

        IOutputTerminal<Pulse> IsReleased { get; }
    }
}
