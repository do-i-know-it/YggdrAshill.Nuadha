using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="ICalibration{TSignal}"/>.
    /// </summary>
    public static class CalibrationExtension
    {
        public static ICorrection<TSignal> ToCorrection<TSignal>(this ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
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

            return new Correction<TSignal>(calibration, generation);
        }
        private sealed class Correction<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly ICalibration<TSignal> calibration;

            private readonly IGeneration<TSignal> generation;

            internal Correction(ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
            {
                this.calibration = calibration;

                this.generation = generation;
            }

            public TSignal Correct(TSignal signal)
            {
                var offset = generation.Generate();

                return calibration.Calibrate(signal, offset);
            }
        }

        public static IConversion<TSignal, TSignal> ToConversion<TSignal>(this ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
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

            return calibration.ToCorrection(generation).ToConversion();
        }
    }
}
