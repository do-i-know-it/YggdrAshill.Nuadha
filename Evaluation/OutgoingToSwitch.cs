using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/> to switch.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to switch.
    /// </typeparam>
    public sealed class OutgoingToSwitch<TSignal> : IOutgoingMessage<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutgoingMessage<TSignal> then;
        private readonly IOutgoingMessage<TSignal> otherwise;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="then">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/> detected.
        /// </param>
        /// <param name="otherwise">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TSignal"/> not detected.
        /// </param>
        public OutgoingToSwitch(IDetection<TSignal> detection, IOutgoingMessage<TSignal> then, IOutgoingMessage<TSignal> otherwise)
        {
            this.detection = detection;
            this.then = then;
            this.otherwise = otherwise;
        }

        /// <summary>
        /// Submits <paramref name="signal"/> to switch.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to switch.
        /// </param>
        public void Submit(TSignal signal)
        {
            if (detection.Detect(signal))
            {
                then.Submit(signal);
            }
            else
            {
                otherwise.Submit(signal);
            }
        }
    }
}
