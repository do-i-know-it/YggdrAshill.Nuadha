using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for Transformation.
    /// </summary>
    public static class TransformationExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TInput}"/> to convert.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TOutput}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return new Converter<TInput, TOutput>(production, conversion);
        }

        /// <summary>
        /// Corrects <typeparamref name="TSignal"/> with <see cref="Func{TSignal, TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to correct.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to correct.
        /// </param>
        /// <param name="correction">
        /// <see cref="ICorrection{TSignal}"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> corrected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="correction"/> is null.
        /// </exception>
        public static IProduction<TSignal> Convert<TSignal>(this IProduction<TSignal> production, ICorrection<TSignal> correction)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return production.Convert(new Correct<TSignal>(correction));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pulse"/> with <see cref="Func{TSignal, Pulse}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IPulsation{TSignal}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{Pulse}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, IPulsation<TSignal> pulsation)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return production.Convert(new Pulsate<TSignal>(pulsation));
        }

        /// <summary>
        /// Detects <see cref="Notice"/> from <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detector<TSignal>(production, detection);
        }
    }
}
