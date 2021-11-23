using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConversionExtension
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
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TOutput"/>.
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

            return ProduceSignalTo.Convert(production, translation);
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
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TOutput"/>.
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

            return production.Convert(SignalInto.Signal(translation));
        }

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

            return production.Convert(SignalInto.Note(notation));
        }
        
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

            return production.Convert(SignalInto.Note(notation));
        }

        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, INotification<TSignal> condition)
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

            return production.Convert(PulseFrom.Signal(condition));
        }

        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> condition)
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

            return production.Convert(NoticeOf.Signal(condition));
        }
    }
}
