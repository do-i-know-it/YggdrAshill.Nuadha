using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class OutgoingToConvert<TInput, TOutput> : IOutgoingFlow<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;
        private readonly IOutgoingFlow<TOutput> outgoingFlow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        public OutgoingToConvert(IConversion<TInput, TOutput> conversion, IOutgoingFlow<TOutput> outgoingFlow)
        {
            this.conversion = conversion;
            this.outgoingFlow = outgoingFlow;
        }

        /// <summary>
        /// Exports <paramref name="signal"/> to convert.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </param>
        public void Export(TInput signal)
        {
            var converted = conversion.Convert(signal);
            outgoingFlow.Export(converted);
        }
    }
}
