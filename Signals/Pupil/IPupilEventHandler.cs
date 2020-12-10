using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPupilEventHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasOpened { get; }

        IOutputTerminal<Pulse> IsOpened { get; }

        IOutputTerminal<Pulse> HasClosed { get; }

        IOutputTerminal<Pulse> IsClosed { get; }
    }
}
