using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> and <see cref="ICalibration{TSignal}"/> for <see cref="ToCorrectSpace3D"/>.
    /// </summary>
    public static class ToCorrectSpace3D
    {
        public sealed class PositionTo :
            ICalibration<Space3D.Position>
        {
            /// <summary>
            /// Calibrates <see cref="Space3D.Position"/>.
            /// </summary>
            /// <returns>
            /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Space3D.Position"/>.
            /// </returns>
            public static ICalibration<Space3D.Position> Calibrate()
            {
                return Instance;
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

                return SignalInto.SignalTo.Correct(Instance, generation);
            }

            private static PositionTo Instance { get; } = new PositionTo();

            private PositionTo()
            {

            }

            /// <inheritdoc/>
            public Space3D.Position Calibrate(Space3D.Position signal, Space3D.Position offset)
            {
                return signal + offset;
            }
        }

        public sealed class RotationTo :
            ICalibration<Space3D.Rotation>
        {
            /// <summary>
            /// Calibrates <see cref="Space3D.Rotation"/>.
            /// </summary>
            /// <returns>
            /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Space3D.Rotation"/>.
            /// </returns>
            public static ICalibration<Space3D.Rotation> Calibrate()
            {
                return Instance;
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

                return SignalInto.SignalTo.Correct(Instance, generation);
            }

            private static RotationTo Instance { get; } = new RotationTo();

            private RotationTo()
            {

            }

            /// <inheritdoc/>
            public Space3D.Rotation Calibrate(Space3D.Rotation signal, Space3D.Rotation offset)
            {
                return signal + offset;
            }
        }
    }
}
