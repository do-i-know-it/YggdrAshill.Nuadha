using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Modification
{
    /// <summary>
    /// <see cref="IIncomingMessage{TSignal}"/> for <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class IncomingToConvert<TInput, TOutput> : IIncomingMessage<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IIncomingMessage<TInput> incomingMessage;
        private readonly IConversion<TInput, TOutput> conversion;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="incomingMessage">
        /// <see cref="IIncomingMessage{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        public IncomingToConvert(IIncomingMessage<TInput> incomingMessage, IConversion<TInput, TOutput> conversion)
        {
            this.incomingMessage = incomingMessage;
            this.conversion = conversion;
        }

        /// <summary>
        /// Subscribes <paramref name="message"/> to convert.
        /// </summary>
        /// <param name="message">
        /// <see cref="IOutgoingMessage{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public IDisposable Subscribe(IOutgoingMessage<TOutput> message)
        {
            var outgoingMessage = new OutgoingToConvert<TInput, TOutput>(conversion, message);
            return incomingMessage.Subscribe(outgoingMessage);
        }
    }
}
