namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Propagates <typeparamref name="TSignal"/> to each connected <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    public interface IPropagation<TSignal> :
        IConsumption<TSignal>,
        IConnection<TSignal>,
        IDisconnection
        where TSignal : ISignal
    {

    }
}
