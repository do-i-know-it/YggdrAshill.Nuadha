namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends received <typeparamref name="TSignal"/> to each of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    public interface IPropagation<TSignal> :
        IProduction<TSignal>,
        IConsumption<TSignal>
        where TSignal : ISignal
    {

    }
}
