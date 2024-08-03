using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IOutflow{TSignal}"/> for <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class OutgoingToConvert<TInput, TOutput> : IOutflow<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;
        private readonly IOutflow<TOutput> outflow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        public OutgoingToConvert(IConversion<TInput, TOutput> conversion, IOutflow<TOutput> outflow)
        {
            this.conversion = conversion;
            this.outflow = outflow;
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
            outflow.Export(converted);
        }
    }
}
