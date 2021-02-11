using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Collects <see cref="IConsumption{TSignal}"/> to send <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IConnection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Collects <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <param name="consumption">
        /// Destination to send <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// Token to disconnect <paramref name="consumption"/>.
        /// </returns>
        IDisconnection Connect(IConsumption<TSignal> consumption);
    }
}
