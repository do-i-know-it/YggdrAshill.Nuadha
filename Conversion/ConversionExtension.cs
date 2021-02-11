using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Extension for Conversion.
    /// </summary>
    public static class ConversionExtension
    {
        #region Translation

        /// <summary>
        /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/> with <see cref="ITranslation{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TInput}"/> to tanslate.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to translate.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TOutput}"/> translated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="connection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IConnection<TOutput> Translate<TInput, TOutput>(this IConnection<TInput> connection, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translator<TInput, TOutput>(connection, translation);
        }

        /// <summary>
        /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/> with <see cref="ITranslation{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{TOutput}"/> translated.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to translate.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TInput}"/> to tanslate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IConsumption<TInput> Translate<TInput, TOutput>(this IConsumption<TOutput> consumption, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translate<TInput, TOutput>(consumption, translation);
        }

        #endregion

        #region Correction

        /// <summary>
        /// Corrects <typeparamref name="TSignal"/> with <see cref="ICalculation{TSignal}"/> and <see cref="IGeneration{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for correction.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to correct.
        /// </param>
        /// <param name="calculation">
        /// <see cref="ICalculation{TSignal}"/> to correct.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TSignal}"/> corrected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="connection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calculation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConnection<TSignal> Correct<TSignal>(this IConnection<TSignal> connection, ICalculation<TSignal> calculation, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }

            return connection.Translate(new Correct<TSignal>(calculation, generation));
        }

        /// <summary>
        /// Corrects <typeparamref name="TSignal"/> with <see cref="ICalculation{TSignal}"/> and <see cref="IGeneration{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for correction.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> corrected.
        /// </param>
        /// <param name="calculation">
        /// <see cref="ICalculation{TSignal}"/> to correct.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to correct.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calculation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Correct<TSignal>(this IConsumption<TSignal> consumption, ICalculation<TSignal> calculation, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }

            return consumption.Translate(new Correct<TSignal>(calculation, generation));
        }

        #endregion

        #region Notation

        /// <summary>
        /// Notates <typeparamref name="TSignal"/> with <see cref="INotation{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for notation.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to notate.
        /// </param>
        /// <param name="notation">
        /// <see cref="INotation{TSignal}"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{Note}"/> notated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="connection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IConnection<Note> Notate<TSignal>(this IConnection<TSignal> connection, INotation<TSignal> notation)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return connection.Translate(new Notate<TSignal>(notation));
        }

        /// <summary>
        /// Notates <typeparamref name="TSignal"/> with <see cref="INotation{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for notation.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{Note}"/> notated.
        /// </param>
        /// <param name="notation">
        /// <see cref="INotation{TSignal}"/> to notate.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to notate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Notate<TSignal>(this IConsumption<Note> consumption, INotation<TSignal> notation)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return consumption.Translate(new Notate<TSignal>(notation));
        }

        #endregion

        #region Detection

        /// <summary>
        /// Detects <typeparamref name="TSignal"/> with <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for detection.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{Pulse}"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="connection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IConnection<Pulse> Detect<TSignal>(this IConnection<TSignal> connection, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detector<TSignal>(connection, detection);
        }

        /// <summary>
        /// Detects <typeparamref name="TSignal"/> with <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for detection.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{Pulse}"/> detected.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to detect.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Detect<TSignal>(this IConsumption<Pulse> consumption, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detect<TSignal>(consumption, detection);
        }

        #endregion
    }
}
