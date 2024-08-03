using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IIncomingMessage{TSignal}"/> for <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class IncomingToDetect<TSignal> : IIncomingMessage<TSignal>
        where TSignal : ISignal
    {
        private readonly IIncomingMessage<TSignal> incomingMessage;
        private readonly IDetection<TSignal> detection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="incomingMessage">
        /// <see cref="IIncomingMessage{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        public IncomingToDetect(IIncomingMessage<TSignal> incomingMessage, IDetection<TSignal> detection)
        {
            this.incomingMessage = incomingMessage;
            this.detection = detection;
        }

        /// <summary>
        /// Subscribes <paramref name="message"/> to detect.
        /// </summary>
        /// <param name="message">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Subscribe(IOutgoingMessage<TSignal> message)
        {
            var outgoingMessage = new OutgoingToDetect<TSignal>(detection, message);
            return incomingMessage.Subscribe(outgoingMessage);
        }
    }
}
