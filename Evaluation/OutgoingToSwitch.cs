using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TSignal"/> to switch.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to switch.
    /// </typeparam>
    public sealed class OutgoingToSwitch<TSignal> : IOutgoingFlow<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutgoingFlow<TSignal> then;
        private readonly IOutgoingFlow<TSignal> otherwise;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="then">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TSignal"/> detected.
        /// </param>
        /// <param name="otherwise">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TSignal"/> not detected.
        /// </param>
        public OutgoingToSwitch(IDetection<TSignal> detection, IOutgoingFlow<TSignal> then, IOutgoingFlow<TSignal> otherwise)
        {
            this.detection = detection;
            this.then = then;
            this.otherwise = otherwise;
        }

        /// <summary>
        /// Exports <paramref name="signal"/> to switch.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to switch.
        /// </param>
        public void Export(TSignal signal)
        {
            if (detection.Detect(signal))
            {
                then.Export(signal);
            }
            else
            {
                otherwise.Export(signal);
            }
        }
    }
}
