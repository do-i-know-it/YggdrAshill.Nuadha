using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IIncomingMessage{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// Produces <see cref="Pulse"/> detected from <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class IncomingPulseFrom<TSignal> : IIncomingMessage<Pulse>
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
        public IncomingPulseFrom(IIncomingMessage<TSignal> incomingMessage, IDetection<TSignal> detection)
        {
            this.incomingMessage = incomingMessage;
            this.detection = detection;
        }

        /// <summary>
        /// Submits <paramref name="message"/> to detect.
        /// </summary>
        /// <param name="message">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Subscribe(IOutgoingMessage<Pulse> message)
        {
            var detected = new OutgoingPulseFrom<TSignal>(detection, message);
            return incomingMessage.Subscribe(detected);
        }
    }
}
