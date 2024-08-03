using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IOutflow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class OutgoingPulseFrom<TSignal> : IOutflow<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutflow<Pulse> outflow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        public OutgoingPulseFrom(IDetection<TSignal> detection, IOutflow<Pulse> outflow)
        {
            this.detection = detection;
            this.outflow = outflow;
        }

        /// <summary>
        /// Exports <paramref name="signal"/> to detect <see cref="Pulse"/>.
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

            outflow.Export(Pulse.Default);
        }
    }
}
