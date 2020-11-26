namespace YggdrAshill.Nuadha.Signalization
{
    public interface IInputTerminal<TSignal>
        where TSignal : ISignal
    {
        void Receive(TSignal signal);
    }
}
