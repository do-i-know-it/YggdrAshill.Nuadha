using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ToCorrect
    {
        public static class Space3D
        {
            public sealed class PositionTo :
                ICalibration<Signals.Space3D.Position>
            {
                public static ICalibration<Signals.Space3D.Position> Calibrate()
                {
                    return Instance;
                }

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

                public Signals.Space3D.Position Calibrate(Signals.Space3D.Position signal, Signals.Space3D.Position offset)
                {
                    return signal + offset;
                }
            }

            public sealed class RotationTo :
                ICalibration<Signals.Space3D.Rotation>
            {
                public static ICalibration<Signals.Space3D.Rotation> Calibrate()
                {
                    return Instance;
                }

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

                public Signals.Space3D.Rotation Calibrate(Signals.Space3D.Rotation signal, Signals.Space3D.Rotation offset)
                {
                    return signal + offset;
                }
            }
        }
    }
}
