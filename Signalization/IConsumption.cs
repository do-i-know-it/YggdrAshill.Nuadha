namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Consumes <typeparamref name="TSignal"/> received.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to consume.
    /// </typeparam>
    public interface IConsumption<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Receives <typeparamref name="TSignal"/> to consume.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> received.
        /// </param>
        void Consume(TSignal signal);
    }
}
