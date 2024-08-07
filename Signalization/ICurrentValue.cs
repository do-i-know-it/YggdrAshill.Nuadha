namespace YggdrAshill.Nuadha.Signalization
{
    public interface ICurrentValue<out TSignal> : IIncomingFlow<TSignal>
        where TSignal : ISignal
    {
        TSignal Value { get; }
    }
}
