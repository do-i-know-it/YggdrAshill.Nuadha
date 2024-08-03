namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> received from <see cref="IIncomingMessage{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IOutgoingMessage<in TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Submits <paramref name="signal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> received.
        /// </param>
        void Submit(TSignal signal);
    }
}
