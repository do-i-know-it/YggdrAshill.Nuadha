using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class IncomingToDetect<TSignal> : IIncomingFlow<TSignal>
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
        public IncomingToDetect(IIncomingFlow<TSignal> incomingFlow, IDetection<TSignal> detection)
        {
            this.incomingFlow = incomingFlow;
            this.detection = detection;
        }

        /// <summary>
        /// Imports <paramref name="outgoingFlow"/> to detect.
        /// </summary>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for detected <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutgoingFlow<TSignal> outgoingFlow)
        {
            var flow = new OutgoingToDetect<TSignal>(detection, outgoingFlow);
            return incomingFlow.Import(flow);
        }
    }
}
