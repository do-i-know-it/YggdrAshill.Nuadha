using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IConversion{TInput, TOutput}"/>.
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
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputToMedium"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediumToOutput"/> is null.
        /// </exception>
        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            if (inputToMedium == null)
            {
                throw new ArgumentNullException(nameof(inputToMedium));
            }
            if (mediumToOutput == null)
            {
                throw new ArgumentNullException(nameof(mediumToOutput));
            }

            return From<TInput>.Into<TOutput>.Via(inputToMedium, mediumToOutput);
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
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputToMedium"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediumToOutput"/> is null.
        /// </exception>
        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, Func<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            if (inputToMedium == null)
            {
                throw new ArgumentNullException(nameof(inputToMedium));
            }
            if (mediumToOutput == null)
            {
                throw new ArgumentNullException(nameof(mediumToOutput));
            }

            return inputToMedium.Then(From<TMedium>.Into<TOutput>.Like(mediumToOutput));
        }

        public static IDetection<TSignal> ToDetect<TSignal, TMedium>(this IConversion<TSignal, TMedium> conversion, IDetection<TMedium> detection)
            where TSignal : ISignal
            where TMedium : ISignal
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new ConvertToDetect<TSignal, TMedium>(conversion, detection);
        }

        public static IDetection<TSignal> ToDetect<TSignal, TMedium>(this IConversion<TSignal, TMedium> conversion, Func<TMedium, bool> detection)
            where TSignal : ISignal
            where TMedium : ISignal
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return conversion.ToDetect(That<TMedium>.Is(detection));
        }
    }
}
