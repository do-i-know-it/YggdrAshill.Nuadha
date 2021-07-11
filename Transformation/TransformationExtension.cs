using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for Transformation.
    /// </summary>
    public static class TransformationExtension
    {
        #region Convert

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
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/> to convert.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/> converted.
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
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/> to convert.
        /// </param>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/> converted.
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
        private sealed class Conversion<TInput, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly Func<TInput, TOutput> onConverted;

            internal Conversion(Func<TInput, TOutput> onConverted)
            {
                if (onConverted == null)
                {
                    throw new ArgumentNullException(nameof(onConverted));
                }

                this.onConverted = onConverted;
            }

            /// <inheritdoc/>
            public TOutput Convert(TInput signal)
            {
                return onConverted.Invoke(signal);
            }
        }

        #endregion

        #region Correct

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to correct.
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
        /// Converts <typeparamref name="TSignal"/> to correct.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to correct.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to correct.
        /// </param>
        /// <param name="correction">
        /// <see cref="Func{T, TResult}"/> to correct <typeparamref name="TSignal"/>.
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
        private sealed class Correction<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, TSignal> onCorrected;

            internal Correction(Func<TSignal, TSignal> onCorrected)
            {
                if (onCorrected == null)
                {
                    throw new ArgumentNullException(nameof(onCorrected));
                }

                this.onCorrected = onCorrected;
            }

            /// <inheritdoc/>
            public TSignal Correct(TSignal signal)
            {
                return onCorrected.Invoke(signal);
            }
        }

        #endregion

        #region Detect

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
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
        /// <see cref="IProduction{TSignal}"/> for <see cref="Notice"/> detected.
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

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Notice"/> detected.
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

            return production.Detect(new Detection<TSignal>(detection));
        }
        private sealed class Detection<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, bool> onDetected;

            public Detection(Func<TSignal, bool> onDetected)
            {
                this.onDetected = onDetected;
            }

            /// <inheritdoc/>
            public bool Detect(TSignal signal)
            {
                return onDetected.Invoke(signal);
            }
        }

        /// <summary>
        /// Produces <see cref="Notice"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Notice"/> to produce.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action"/> executed when this has consumed <see cref="Notice"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
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

        #endregion
    }
}
