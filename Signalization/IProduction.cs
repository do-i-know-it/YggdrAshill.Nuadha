namespace YggdrAshill.Nuadha.Signalization
{
    public interface IProduction<TSignal>
        where TSignal : ISignal
    {
        IEmission Produce(IConsumption<TSignal> consumption);
    }
}
