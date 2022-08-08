namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Produces <typeparamref name="TSignal"/> to send.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to produce.
    /// </typeparam>
    public interface IProduction<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Sends produced <typeparamref name="TSignal"/> to <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel sending.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        ICancellation Produce(IConsumption<TSignal> consumption);
    }
}
