using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IInflow{TSignal}"/> for <typeparamref name="TSignal"/> detected by <see cref="IDetection{TSignal}"/>
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class IncomingToDetect<TSignal> : IInflow<TSignal>
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
        public IncomingToDetect(IInflow<TSignal> inflow, IDetection<TSignal> detection)
        {
            this.inflow = inflow;
            this.detection = detection;
        }

        /// <summary>
        /// Imports <paramref name="outflow"/> to detect.
        /// </summary>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for detected <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutflow<TSignal> outflow)
        {
            var flow = new OutgoingToDetect<TSignal>(detection, outflow);
            return inflow.Import(flow);
        }
    }
}
