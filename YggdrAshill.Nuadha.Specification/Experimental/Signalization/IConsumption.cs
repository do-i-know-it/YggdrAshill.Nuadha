namespace YggdrAshill.Nuadha.Signalization.Experimental
{
    /// <summary>
    /// Receives <typeparamref name="TSignal"/> to consume.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to receive.
    /// </typeparam>
    public interface IConsumption<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Consumes <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to consume.
        /// </param>
        void Consume(TSignal signal);
    }
}
