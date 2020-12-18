using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Translation
{
    public interface IPulseEventOutputHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pulse> HasEnabled { get; }

        IOutputTerminal<Pulse> IsEnabled { get; }

        IOutputTerminal<Pulse> HasDisabled { get; }

        IOutputTerminal<Pulse> IsDisabled { get; }
    }
}
