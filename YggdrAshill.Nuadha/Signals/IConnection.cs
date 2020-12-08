using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public interface IConnection<TSignal>
        where TSignal : ISignal
    {
        IDisconnection Connect(IOutputTerminal<TSignal> terminal);
    }
}
