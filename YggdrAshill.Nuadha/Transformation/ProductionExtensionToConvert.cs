using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> to convert.
    /// </summary>
    public static class ProductionExtensionToConvert
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
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertWhen<TInput, TOutput>.IsProduced(production, translation);
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
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, Func<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return production.Convert(From<TInput>.Into(translation));
        }
        
        /// <summary>
        /// Corrects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to correct.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> for <typeparamref name="TSignal"/> to correct.
        /// </param>
        /// <param name="offset">
        /// <see cref="IOffset{TSignal}"/> for <typeparamref name="TSignal"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calibration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="offset"/> is null.
        /// </exception>
        public static IProduction<TSignal> Correct<TSignal>(this IProduction<TSignal> production, ICalibration<TSignal> calibration, IOffset<TSignal> offset)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (offset == null)
            {
                throw new ArgumentNullException(nameof(offset));
            }

            return production.Convert(ToCorrect<TSignal>.With(calibration, offset));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Note"/> to notate.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notate.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to notate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IProduction<Note> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, string> notation)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return production.Convert(IntoNote.From(notation));
        }

        /// <summary>
        /// Converts <see cref="Note"/> into <see cref="Note"/> to notate.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Note"/>.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to notate <see cref="Note"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IProduction<Note> Convert(this IProduction<Note> production, Func<string, string> notation)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return production.Convert(IntoNote.FromNote(notation));
        }
    }
}
