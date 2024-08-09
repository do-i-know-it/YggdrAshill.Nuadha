using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IOutgoingFlow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class OutgoingToDetect<TSignal> : IOutgoingFlow<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;
        private readonly IOutgoingFlow<Pulse> outgoingFlow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        public OutgoingToDetect(IDetection<TSignal> detection, IOutgoingFlow<Pulse> outgoingFlow)
        {
            this.detection = detection;
            this.outgoingFlow = outgoingFlow;
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

            outgoingFlow.Export(Pulse.Default);
        }
    }
}
