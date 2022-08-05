using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ICalibration{TSignal}"/> and <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Space3D"/>.
    /// </summary>
    public static class FromSpace3D
    {
        /// <summary>
        /// Defines implementations of <see cref="ICalibration{TSignal}"/> and <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Space3D.Position"/>.
        /// </summary>
        public static class PositionInto
        {
            /// <summary>
            /// Calibrates <see cref="Space3D.Position"/>.
            /// </summary>
            public static ICalibration<Space3D.Position> PositionWith { get; } = new CalibratePosition();
            private sealed class CalibratePosition :
                ICalibration<Space3D.Position>
            {
                public Space3D.Position Calibrate(Space3D.Position signal, Space3D.Position offset)
                {
                    return signal + offset;
                }
            }
        }

        /// <summary>
        /// Defines implementations of <see cref="ICalibration{TSignal}"/> and <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Space3D.Rotation"/>.
        /// </summary>
        public static class RotationInto
        {
            /// <summary>
            /// Calibrates <see cref="Space3D.Rotation"/>.
            /// </summary>
            public static ICalibration<Space3D.Rotation> RotationWith { get; } = new CalibrateRotation();
            private sealed class CalibrateRotation :
                ICalibration<Space3D.Rotation>
            {
                public Space3D.Rotation Calibrate(Space3D.Rotation signal, Space3D.Rotation offset)
                {
                    return signal + offset;
                }
            }
        }

        /// <summary>
        /// Defines implementations of <see cref="ICalibration{TSignal}"/> and <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Space3D.Pose"/>.
        /// </summary>
        public static class PoseInto
        {
            /// <summary>
            /// Calibrates <see cref="Space3D.Pose"/>.
            /// </summary>
            public static ICalibration<Space3D.Pose> PoseWith { get; } = new CalibratePose();
            private sealed class CalibratePose :
                ICalibration<Space3D.Pose>
            {
                public Space3D.Pose Calibrate(Space3D.Pose signal, Space3D.Pose offset)
                {
                    return signal + offset;
                }
            }
        }
    }
}
