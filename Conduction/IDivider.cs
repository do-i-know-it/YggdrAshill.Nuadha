using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    public interface IDivider<TSignal>
        where TSignal : ISignal
    {
        IDisconnection Connect(IOutputTerminal<TSignal> terminal);
    }
}
