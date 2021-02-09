using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    public static class ConversionExtension
    {
        #region Translation

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

            return connection.Translate(new Correct<TSignal>(correction));
        }

        public static IConsumption<TSignal> Correct<TSignal>(this IConsumption<TSignal> consumption, ICorrection<TSignal> correction)
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

            return consumption.Translate(new Correct<TSignal>(correction));
        }

        #endregion

        #region Calibration

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

            return connection.Correct(new Calibrate<TSignal>(reduction, calibration));
        }

        public static IConsumption<TSignal> Calibrate<TSignal>(this IConsumption<TSignal> consumption, IReduction<TSignal> reduction, ICalibration<TSignal> calibration)
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

            return consumption.Correct(new Calibrate<TSignal>(reduction, calibration));
        }

        #endregion

        #region Notation

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
