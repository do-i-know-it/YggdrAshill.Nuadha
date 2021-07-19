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
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TOutput"/>.
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

            return production.Convert(SignalInto.Signal(conversion));
        }

        #endregion

        #region Calibrate

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to calibrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to calibrate.
        /// </typeparam>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate offset of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to calibrate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calibration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalInto.SignalTo.Correct(calibration, generation);
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to calibrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to calibrate.
        /// </typeparam>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate offset of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to calibrate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calibration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this ICalibration<TSignal> calibration, Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalInto.SignalTo.Correct(calibration, generation);
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to calibrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to calibrate.
        /// </typeparam>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> to convert.
        /// </param>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> for offset.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to calibrate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calibration"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this ICalibration<TSignal> calibration, TSignal signal)
            where TSignal : ISignal
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return SignalInto.SignalTo.Correct(calibration, signal);
        }

        #endregion

        #region Filtrate

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to filtrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to filtrate.
        /// </typeparam>
        /// <param name="filtration">
        /// <see cref="IFiltration{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to initialize <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to filtrate <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="filtration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this IFiltration<TSignal> filtration, IGeneration<TSignal> generation)
           where TSignal : ISignal
        {
            if (filtration == null)
            {
                throw new ArgumentNullException(nameof(filtration));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalInto.SignalTo.Correct(filtration, generation);
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to filtrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to filtrate.
        /// </typeparam>
        /// <param name="filtration">
        /// <see cref="IFiltration{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to initialize <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to filtrate <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="filtration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this IFiltration<TSignal> filtration, Func<TSignal> generation)
           where TSignal : ISignal
        {
            if (filtration == null)
            {
                throw new ArgumentNullException(nameof(filtration));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalInto.SignalTo.Correct(filtration, generation);
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to filtrate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to filtrate.
        /// </typeparam>
        /// <param name="filtration">
        /// <see cref="IFiltration{TSignal}"/> to convert.
        /// </param>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> for initial.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to filtrate <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="filtration"/> is null.
        /// </exception>
        public static IConversion<TSignal, TSignal> ToConvert<TSignal>(this IFiltration<TSignal> filtration, TSignal signal)
           where TSignal : ISignal
        {
            if (filtration == null)
            {
                throw new ArgumentNullException(nameof(filtration));
            }

            return SignalInto.SignalTo.Correct(filtration, signal);
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
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to send <see cref="Notice"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> condition)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return production.Detect(NoticeOf.Signal(condition));
        }

        /// <summary>
        /// Sends <see cref="Notice"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <see cref="Notice"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action"/> to receive <see cref="Notice"/>.
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
