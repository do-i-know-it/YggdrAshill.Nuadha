using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Translation.Experimental
{
    public static class TranslationExtension
    {
        public static IConnection<TOutput> Convert<TInput, TOutput>(this IConnection<TInput> connection, IConversion<TInput, TOutput> conversion)
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

            return new Converter<TInput, TOutput>(connection, conversion);
        }

        public static IConnection<TSignal> Correct<TSignal>(this IConnection<TSignal> connection, ICorrection<TSignal> correction)
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

            return connection.Convert(new Corrector<TSignal>(correction));
        }

        public static IConnection<TSignal> Calibrate<TSignal>(this IConnection<TSignal> connection, IReduction<TSignal> reduction, ICalibration<TSignal> calibration)
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

            return connection.Correct(new Calibrator<TSignal>(reduction, calibration));
        }

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
    }
}
