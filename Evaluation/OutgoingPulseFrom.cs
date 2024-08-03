using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IOutgoingMessage{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class OutgoingPulseFrom<TSignal> : IOutgoingMessage<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutgoingMessage<Pulse> outgoingMessage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="outgoingMessage">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        public OutgoingPulseFrom(IDetection<TSignal> detection, IOutgoingMessage<Pulse> outgoingMessage)
        {
            this.detection = detection;
            this.outgoingMessage = outgoingMessage;
        }

        /// <summary>
        /// Submits <paramref name="signal"/> to detect <see cref="Pulse"/>.
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

            outgoingMessage.Submit(Pulse.Default);
        }
    }
}
