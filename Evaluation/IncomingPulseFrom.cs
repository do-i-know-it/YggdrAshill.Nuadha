using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IIncomingFlow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect <see cref="Pulse"/>.
    /// </typeparam>
    public sealed class IncomingPulseFrom<TSignal> : IIncomingFlow<Pulse>
        where TSignal : ISignal
    {
        private readonly IIncomingFlow<TSignal> incomingFlow;
        private readonly IDetection<TSignal> detection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        public IncomingPulseFrom(IIncomingFlow<TSignal> incomingFlow, IDetection<TSignal> detection)
        {
            this.incomingFlow = incomingFlow;
            this.detection = detection;
        }

        /// <summary>
        /// Imports <paramref name="outgoingFlow"/> to detect.
        /// </summary>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutgoingFlow<Pulse> outgoingFlow)
        {
            var flow = new OutgoingPulseFrom<TSignal>(detection, outgoingFlow);
            return incomingFlow.Import(flow);
        }
    }
}
