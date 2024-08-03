using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Modification
{
    /// <summary>
    /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class OutgoingToDetect<TSignal> : IOutgoingMessage<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutgoingMessage<TSignal> outgoingMessage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="outgoingMessage">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        public OutgoingToDetect(IDetection<TSignal> detection, IOutgoingMessage<TSignal> outgoingMessage)
        {
            this.detection = detection;
            this.outgoingMessage = outgoingMessage;
        }

        /// <summary>
        /// Submits <paramref name="signal"/> to detect.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to detect.
        /// </param>
        public void Submit(TSignal signal)
        {
            if (!detection.Detect(signal))
            {
                return;
            }

            outgoingMessage.Submit(signal);
        }
    }
}
