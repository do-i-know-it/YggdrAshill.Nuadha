using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IOutflow{TSignal}"/> for <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class OutgoingToDetect<TSignal> : IOutflow<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutflow<TSignal> outflow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        public OutgoingToDetect(IDetection<TSignal> detection, IOutflow<TSignal> outflow)
        {
            this.detection = detection;
            this.outflow = outflow;
        }

        /// <summary>
        /// Exports <paramref name="signal"/> to detect.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to detect.
        /// </param>
        public void Export(TSignal signal)
        {
            if (!detection.Detect(signal))
            {
                return;
            }

            outflow.Export(signal);
        }
    }
}
