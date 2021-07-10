namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IProduction<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Produces <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <param name="consumption">
        /// Destination to send <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        ICancellation Produce(IConsumption<TSignal> consumption);
    }
}
