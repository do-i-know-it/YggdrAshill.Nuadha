using System;
using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IConversion{TInput,TOutput}"/>.
    /// </summary>
    public static class ConversionExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> via <typeparamref name="TMedium"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert into <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <param name="inputToMedium">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </returns>
        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            return new ConvertIntermediate<TInput,TMedium,TOutput>(inputToMedium, mediumToOutput);
        }

        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> via <typeparamref name="TMedium"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert into <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <param name="inputToMedium">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </returns>
        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, Func<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            var conversion = new Conversion<TMedium, TOutput>(mediumToOutput);
            return inputToMedium.Then(conversion);
        }

        public static IConversion<TSignal, TSignal> ToCalibrate<TSignal>(this IConversion<TSignal, Accuracy<TSignal>> conversion, IConversion<Accuracy<TSignal>, TSignal> calibration)
            where TSignal : ISignal
        {
            return conversion.Then(calibration);
        }

        public static IConversion<TSignal, TSignal> ToCalibrate<TSignal>(this IConversion<TSignal, Accuracy<TSignal>> conversion, Func<Accuracy<TSignal>, TSignal> calibration)
            where TSignal : ISignal
        {
            return conversion.Then(calibration);
        }

        public static IConversion<TSignal, TSignal> ToFiltrate<TSignal>(this IConversion<TSignal, Sequence<TSignal>> conversion, IConversion<Sequence<TSignal>, TSignal> filtration)
            where TSignal : ISignal
        {
            return conversion.Then(filtration);
        }

        public static IConversion<TSignal, TSignal> ToFiltrate<TSignal>(this IConversion<TSignal, Sequence<TSignal>> conversion, Func<Sequence<TSignal>, TSignal> filtration)
            where TSignal : ISignal
        {
            return conversion.Then(filtration);
        }
    }
}
