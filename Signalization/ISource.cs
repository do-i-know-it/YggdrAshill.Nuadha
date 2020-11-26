namespace YggdrAshill.Nuadha.Signalization
{
    public interface ISource<TSignal>
        where TSignal : ISignal
    {
        IEmission Connect(IInputTerminal<TSignal> terminal);
    }
}
