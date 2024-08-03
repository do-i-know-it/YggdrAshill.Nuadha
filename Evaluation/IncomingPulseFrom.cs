using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// <see cref="IInflow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect <see cref="Pulse"/>.
    /// </typeparam>
    public sealed class IncomingPulseFrom<TSignal> : IInflow<Pulse>
        where TSignal : ISignal
    {
        private readonly IInflow<TSignal> inflow;
        private readonly IDetection<TSignal> detection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inflow">
        /// <see cref="IInflow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        public IncomingPulseFrom(IInflow<TSignal> inflow, IDetection<TSignal> detection)
        {
            this.inflow = inflow;
            this.detection = detection;
        }

        /// <summary>
        /// Imports <paramref name="outflow"/> to detect.
        /// </summary>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutflow<Pulse> outflow)
        {
            var flow = new OutgoingPulseFrom<TSignal>(detection, outflow);
            return inflow.Import(flow);
        }
    }
}
