using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IBlinkEventInputHandler :
        IHardwareHandler
    {
        IInputTerminal<Pulse> HasOpened { get; }

        IInputTerminal<Pulse> IsOpened { get; }

        IInputTerminal<Pulse> HasClosed { get; }

        IInputTerminal<Pulse> IsClosed { get; }
    }
}
