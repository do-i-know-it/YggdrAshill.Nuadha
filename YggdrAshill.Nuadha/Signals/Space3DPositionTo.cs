using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of Trasformation for <see cref="Space3D.Position"/>.
    /// </summary>
    public static class Space3DPositionTo
    {
        /// <summary>
        /// Calibrates <see cref="Space3D.Position"/>.
        /// </summary>
        /// <returns>
        /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Space3D.Position"/>.
        /// </returns>
        public static ICalibration<Space3D.Position> Calibrate()
        {
            return calibration;
        }
        private static readonly Calibration calibration = new Calibration();
        private sealed class Calibration :
            ICalibration<Space3D.Position>
        {
            public Space3D.Position Calibrate(Space3D.Position signal, Space3D.Position offset)
            {
                return signal + offset;
            }
        }

        /// <summary>
        /// Corrects <see cref="Space3D.Position"/> to calibrate.
        /// </summary>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate offset of <see cref="Space3D.Position"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to correct <see cref="Space3D.Position"/>.
        /// </returns>
        public static ITranslation<Space3D.Position, Space3D.Position> Calibrate(IGeneration<Space3D.Position> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalTo.Correct(Calibrate(), generation);
        }
    }
}
