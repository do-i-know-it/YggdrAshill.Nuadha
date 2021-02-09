using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConversionExtension
    {
        #region Translation

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

        public static IConnection<TSignal> Correct<TSignal>(this IConnection<TSignal> connection, Func<TSignal, TSignal> correction)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return connection.Correct(new Correction<TSignal>(correction));
        }

        public static IConsumption<TSignal> Correct<TSignal>(this IConsumption<TSignal> consumption, Func<TSignal, TSignal> correction)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return consumption.Correct(new Correction<TSignal>(correction));
        }

        #endregion

        #region Calibration

        public static IConnection<TSignal> Calibrate<TSignal>(this IConnection<TSignal> connection, Func<TSignal, TSignal, TSignal> reduction, Func<TSignal> calibration)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(new Reduction<TSignal>(reduction), new Calibration<TSignal>(calibration));
        }

        public static IConsumption<TSignal> Calibrate<TSignal>(this IConsumption<TSignal> consumption, Func<TSignal, TSignal, TSignal> reduction, Func<TSignal> calibration)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return consumption.Calibrate(new Reduction<TSignal>(reduction), new Calibration<TSignal>(calibration));
        }

        #endregion

        #region Notation

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
