using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class OutgoingToConvert<TInput, TOutput> : IOutgoingMessage<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;
        private readonly IOutgoingMessage<TOutput> outgoingMessage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="outgoingMessage">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        public OutgoingToConvert(IConversion<TInput, TOutput> conversion, IOutgoingMessage<TOutput> outgoingMessage)
        {
            this.conversion = conversion;
            this.outgoingMessage = outgoingMessage;
        }

        /// <summary>
        /// Submits <paramref name="signal"/> to convert.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </param>
        public void Submit(TInput signal)
        {
            var converted = conversion.Convert(signal);
            outgoingMessage.Submit(converted);
        }
    }
}
