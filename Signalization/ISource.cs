namespace YggdrAshill.Nuadha.Signalization
{
    public interface ISource<TSignal> : ICurrentValue<TSignal>, IFlow<TSignal>
        where TSignal : ISignal
    {
        TSignal State { get; set; }
    }
}
