using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> to <see cref="IOutgoingMessage{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IIncomingMessage<out TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Subscribes <paramref name="message"/> to send <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="message">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        IDisposable Subscribe(IOutgoingMessage<TSignal> message);
    }
}
