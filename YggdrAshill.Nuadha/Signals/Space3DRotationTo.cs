using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of Transformation for <see cref="Space3D.Rotation"/>.
    /// </summary>
    public static class Space3DRotationTo
    {
        /// <summary>
        /// Calibrates <see cref="Space3D.Rotation"/>.
        /// </summary>
        /// <returns>
        /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Space3D.Rotation"/>.
        /// </returns>
        public static ICalibration<Space3D.Rotation> Calibrate()
        {
            return calibration;
        }
        private static readonly Calibration calibration = new Calibration();
        private sealed class Calibration :
            ICalibration<Space3D.Rotation>
        {
            public Space3D.Rotation Calibrate(Space3D.Rotation signal, Space3D.Rotation offset)
            {
                return signal + offset;
            }
        }

        /// <summary>
        /// Corrects <see cref="Space3D.Rotation"/> to calibrate.
        /// </summary>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate offset of <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to correct <see cref="Space3D.Rotation"/>.
        /// </returns>
        public static ITranslation<Space3D.Rotation, Space3D.Rotation> Calibrate(IGeneration<Space3D.Rotation> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalTo.Correct(Calibrate(), generation);
        }
    }
}
