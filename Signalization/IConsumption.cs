namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Receives <typeparamref name="TSignal"/> to use.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to receive.
    /// </typeparam>
    public interface IConsumption<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Uses <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to use.
        /// </param>
        void Consume(TSignal signal);
    }
}
