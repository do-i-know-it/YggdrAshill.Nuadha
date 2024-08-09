using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IIncomingFlow{TSignal}"/> with <see cref="IConversion{TInput,TOutput}"/>.
    /// </summary>
    public static class IncomingToConvertExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> with <paramref name="conversion"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </returns>
        public static IIncomingFlow<TOutput> Convert<TInput, TOutput>(this IIncomingFlow<TInput> incomingFlow, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            return new IncomingToConvert<TInput,TOutput>(incomingFlow, conversion);
        }

        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> with <paramref name="onConverted"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="onConverted">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </returns>
        public static IIncomingFlow<TOutput> Convert<TInput, TOutput>(this IIncomingFlow<TInput> incomingFlow, Func<TInput, TOutput> onConverted)
            where TInput : ISignal
            where TOutput : ISignal
        {
            var conversion = new Conversion<TInput, TOutput>(onConverted);
            return incomingFlow.Convert(conversion);
        }
    }
}
