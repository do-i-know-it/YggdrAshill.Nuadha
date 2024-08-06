using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class IncomingToConvert<TInput, TOutput> : IIncomingFlow<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IIncomingFlow<TInput> incomingFlow;
        private readonly IConversion<TInput, TOutput> conversion;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        public IncomingToConvert(IIncomingFlow<TInput> incomingFlow, IConversion<TInput, TOutput> conversion)
        {
            this.incomingFlow = incomingFlow;
            this.conversion = conversion;
        }

        /// <summary>
        /// Imports <paramref name="outgoingFlow"/> to convert.
        /// </summary>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for converted <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutgoingFlow<TOutput> outgoingFlow)
        {
            var flow = new OutgoingToConvert<TInput, TOutput>(conversion, outgoingFlow);
            return incomingFlow.Import(flow);
        }
    }
}
