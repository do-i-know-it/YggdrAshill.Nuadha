using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IInflow{TSignal}"/> for <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class IncomingToConvert<TInput, TOutput> : IInflow<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IInflow<TInput> inflow;
        private readonly IConversion<TInput, TOutput> conversion;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inflow">
        /// <see cref="IInflow{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        public IncomingToConvert(IInflow<TInput> inflow, IConversion<TInput, TOutput> conversion)
        {
            this.inflow = inflow;
            this.conversion = conversion;
        }

        /// <summary>
        /// Imports <paramref name="outflow"/> to convert.
        /// </summary>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for converted <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Import(IOutflow<TOutput> outflow)
        {
            var flow = new OutgoingToConvert<TInput, TOutput>(conversion, outflow);
            return inflow.Import(flow);
        }
    }
}
