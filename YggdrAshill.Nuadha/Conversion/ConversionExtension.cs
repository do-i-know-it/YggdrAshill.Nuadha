using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConversionExtension
    {
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
    }
}
