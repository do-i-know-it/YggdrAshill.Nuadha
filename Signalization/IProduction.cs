namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Produces <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to produce.
    /// </typeparam>
    public interface IProduction<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Sends <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to receive <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        ICancellation Produce(IConsumption<TSignal> consumption);
    }
}
