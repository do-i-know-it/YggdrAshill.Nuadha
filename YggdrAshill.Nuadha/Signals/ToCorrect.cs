using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> and <see cref="ICalibration{TSignal}"/>.
    /// </summary>
    public static class ToCorrect
    {
        public static class Space3D
        {
            public sealed class PositionTo :
                ICalibration<Signals.Space3D.Position>
            {
                /// <summary>
                /// Calibrates <see cref="Signals.Space3D.Position"/>.
                /// </summary>
                /// <returns>
                /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Signals.Space3D.Position"/>.
                /// </returns>
                public static ICalibration<Signals.Space3D.Position> Calibrate()
                {
                    return Instance;
                }

                /// <summary>
                /// Corrects <see cref="Signals.Space3D.Position"/> to calibrate.
                /// </summary>
                /// <param name="generation">
                /// <see cref="IGeneration{TSignal}"/> to generate offset of <see cref="Signals.Space3D.Position"/>.
                /// </param>
                /// <returns>
                /// <see cref="IConversion{TInput, TOutput}"/> to correct <see cref="Signals.Space3D.Position"/>.
                /// </returns>
                public static IConversion<Signals.Space3D.Position, Signals.Space3D.Position> Calibrate(IGeneration<Signals.Space3D.Position> generation)
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
                public Signals.Space3D.Position Calibrate(Signals.Space3D.Position signal, Signals.Space3D.Position offset)
                {
                    return signal + offset;
                }
            }

            public sealed class RotationTo :
                ICalibration<Signals.Space3D.Rotation>
            {
                /// <summary>
                /// Calibrates <see cref="Signals.Space3D.Rotation"/>.
                /// </summary>
                /// <returns>
                /// <see cref="ICalibration{TSignal}"/> to correct <see cref="Signals.Space3D.Rotation"/>.
                /// </returns>
                public static ICalibration<Signals.Space3D.Rotation> Calibrate()
                {
                    return Instance;
                }

                /// <summary>
                /// Corrects <see cref="Signals.Space3D.Rotation"/> to calibrate.
                /// </summary>
                /// <param name="generation">
                /// <see cref="IGeneration{TSignal}"/> to generate offset of <see cref="Signals.Space3D.Rotation"/>.
                /// </param>
                /// <returns>
                /// <see cref="IConversion{TInput, TOutput}"/> to correct <see cref="Signals.Space3D.Rotation"/>.
                /// </returns>
                public static IConversion<Signals.Space3D.Rotation, Signals.Space3D.Rotation> Calibrate(IGeneration<Signals.Space3D.Rotation> generation)
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
                public Signals.Space3D.Rotation Calibrate(Signals.Space3D.Rotation signal, Signals.Space3D.Rotation offset)
                {
                    return signal + offset;
                }
            }
        }
    }
}
