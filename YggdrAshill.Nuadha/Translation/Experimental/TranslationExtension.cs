using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Translation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental
{
    public static class TranslationExtension
    {
        public static IConnection<TOutput> Convert<TInput, TOutput>(this IConnection<TInput> connection, Func<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return connection.Convert(new Conversion<TInput, TOutput>(conversion));
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

        public static Conduction.IDisconnection Connect(this IConnection<Pulse> connection, Action onConsumed)
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
