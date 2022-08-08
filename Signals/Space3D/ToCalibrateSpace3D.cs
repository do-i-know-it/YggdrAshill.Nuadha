using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Space3D"/>.
    /// </summary>
    public static class ToCalibrateSpace3D
    {
        /// <summary>
        /// Calibrates <see cref="Space3D.Position"/>.
        /// </summary>
        public static IConversion<Accuracy<Space3D.Position>, Space3D.Position> PositionWith { get; }
            = From<Accuracy<Space3D.Position>>.Into<Space3D.Position>.Like(signal => signal.Original - signal.Error);

        /// <summary>
        /// Calibrates <see cref="Space3D.Rotation"/>.
        /// </summary>
        public static IConversion<Accuracy<Space3D.Rotation>, Space3D.Rotation> RotationWith { get; }
            = From<Accuracy<Space3D.Rotation>>.Into<Space3D.Rotation>.Like(signal => signal.Original - signal.Error);

        /// <summary>
        /// Calibrates <see cref="Space3D.Pose"/>.
        /// </summary>
        public static IConversion<Accuracy<Space3D.Pose>, Space3D.Pose> PoseWith { get; }
            = From<Accuracy<Space3D.Pose>>.Into<Space3D.Pose>.Like(signal => signal.Original - signal.Error);
    }
}
