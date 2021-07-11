using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Transformation.
    /// </summary>
    public static class TransformationExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> with <see cref="Func{TInput, TOutput}"/>.
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
        /// <see cref="Func{TInput, TOutput}"/> to convert.
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
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, Func<TInput, TOutput> conversion)
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

            return production.Convert(new Conversion<TInput, TOutput>(conversion));
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
        /// <see cref="Func{TSignal, TSignal}"/> to correct.
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
        public static IProduction<TSignal> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, TSignal> correction)
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

            return production.Convert(new Correction<TSignal>(correction));
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
        /// <see cref="Func{TSignal, Pulse}"/> to convert.
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
        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, Pulse> pulsation)
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

            return production.Convert(new Pulsation<TSignal>(pulsation));
        }

        /// <summary>
        /// Detects <see cref="Notice"/> from <typeparamref name="TSignal"/> with <see cref="Func{TSignal, bool}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="Func{TSignal, bool}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{Notice}"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> detection)
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

            return production.Detect(detection);
        }

        /// <summary>
        /// Produces with <see cref="Action"/> instead of <see cref="IConsumption{Notice}"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{Notice}"/> to produce.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action"/> to execute when this has consumed <see cref="Notice"/>.
        /// </param>
        /// <returns></returns>
        public static ICancellation Produce(this IProduction<Notice> production, Action consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumption.Invoke();
            });
        }
    }
}
