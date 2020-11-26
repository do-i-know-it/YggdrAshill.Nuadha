namespace YggdrAshill.Nuadha.Signalization
{
    public interface IConnector<TSignal> :
        IInputTerminal<TSignal>,
        IOutputTerminal<TSignal>,
        IDisconnection
        where TSignal : ISignal
    {

    }
}
