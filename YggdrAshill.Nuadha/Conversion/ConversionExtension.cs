using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Extension for Conversion.
    /// </summary>
    public static class ConversionExtension
    {
        #region Translation

        /// <summary>
        /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/> with <see cref="Func{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TInput}"/> to translate.
        /// </param>
        /// <param name="translation">
        /// <see cref="Func{TInput, TOutput}"/> to translate.
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
        public static IConnection<TOutput> Translate<TInput, TOutput>(this IConnection<TInput> connection, Func<TInput, TOutput> translation)
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

            return connection.Translate(new Translation<TInput, TOutput>(translation));
        }

        /// <summary>
        /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/> with <see cref="Func{TInput, TOutput}"/>.
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
        /// <see cref="Func{TInput, TOutput}"/> to translate.
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
        public static IConsumption<TInput> Translate<TInput, TOutput>(this IConsumption<TOutput> consumption, Func<TInput, TOutput> translation)
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

            return consumption.Translate(new Translation<TInput, TOutput>(translation));
        }

        #endregion

        #region Correction

        /// <summary>
        /// Corrects <typeparamref name="TSignal"/> with <see cref="Func{TSignal, TSignal, TSignal}"/> and <see cref="Func{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for correction.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to correct.
        /// </param>
        /// <param name="calculation">
        /// <see cref="Func{TSignal, TSignal, TSignal}"/> to correct.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TSignal}"/> to correct.
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
        public static IConnection<TSignal> Correct<TSignal>(this IConnection<TSignal> connection, Func<TSignal, TSignal, TSignal> calculation, Func<TSignal> generation)
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
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(new Calculation<TSignal>(calculation), new Generation<TSignal>(generation));
        }

        /// <summary>
        /// Corrects <typeparamref name="TSignal"/> with <see cref="Func{TSignal, TSignal, TSignal}"/> and <see cref="Func{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for correction.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> corrected.
        /// </param>
        /// <param name="calculation">
        /// <see cref="Func{TSignal, TSignal, TSignal}"/> to correct.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TSignal}"/> to correct.
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
        public static IConsumption<TSignal> Correct<TSignal>(this IConsumption<TSignal> consumption, Func<TSignal, TSignal, TSignal> calculation, Func<TSignal> generation)
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
                throw new ArgumentNullException(nameof(generation));
            }

            return consumption.Correct(new Calculation<TSignal>(calculation), new Generation<TSignal>(generation));
        }

        #endregion

        #region Notation

        /// <summary>
        /// Notates <typeparamref name="TSignal"/> with <see cref="Func{TSignal, Note}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for notation.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to notate.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{TSignal, Note}"/> to notate.
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
        public static IConnection<Note> Notate<TSignal>(this IConnection<TSignal> connection, Func<TSignal, Note> notation)
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

            return connection.Notate(new Notation<TSignal>(notation));
        }

        /// <summary>
        /// Notates <typeparamref name="TSignal"/> with <see cref="Func{TSignal, Note}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for notation.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{Note}"/> notated.
        /// </param>
        /// <param name="notation">
        /// <see cref="Func{TSignal, Note}"/> to notate.
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
        public static IConsumption<TSignal> Notate<TSignal>(this IConsumption<Note> consumption, Func<TSignal, Note> notation)
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

            return consumption.Notate(new Notation<TSignal>(notation));
        }

        #endregion

        #region Detection

        /// <summary>
        /// Detects <typeparamref name="TSignal"/> with <see cref="Func{TSignal, bool}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for detection.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="Func{TSignal, bool}"/> to detect.
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
        public static IConnection<Pulse> Detect<TSignal>(this IConnection<TSignal> connection, Func<TSignal, bool> detection)
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

            return connection.Detect(new Detection<TSignal>(detection));
        }

        /// <summary>
        /// Detects <typeparamref name="TSignal"/> with <see cref="Func{TSignal, bool}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> for detection.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="IConsumption{Pulse}"/> detected.
        /// </param>
        /// <param name="detection">
        /// <see cref="Func{TSignal, bool}"/> to detect.
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
        public static IConsumption<TSignal> Detect<TSignal>(this IConsumption<Pulse> consumption, Func<TSignal, bool> detection)
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

            return consumption.Detect(new Detection<TSignal>(detection));
        }

        /// <summary>
        /// Connects <see cref="IConnection{Pulse}"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="connection">
        /// <see cref="IConnection{Pulse}"/> to detect.
        /// </param>
        /// <param name="onConsumed">
        /// <see cref="Action"/> to execute when this has detected.
        /// </param>
        /// <returns>
        /// <see cref="IDisconnection"/> to disconnect.
        /// </returns>
        public static IDisconnection Connect(this IConnection<Pulse> connection, Action onConsumed)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            return connection.Connect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                onConsumed.Invoke();
            });
        }

        #endregion
    }
}
