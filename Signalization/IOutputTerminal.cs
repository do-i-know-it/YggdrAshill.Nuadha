namespace YggdrAshill.Nuadha.Signalization
{
    public interface IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        IDisconnection Connect(IInputTerminal<TSignal> terminal);
    }
}
