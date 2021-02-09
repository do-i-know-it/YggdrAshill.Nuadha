namespace YggdrAshill.Nuadha.Signalization
{
    public interface IConsumption<TSignal>
        where TSignal : ISignal
    {
        void Consume(TSignal signal);
    }
}
