using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="IPoseTrackerConfiguration"/>.
    /// </summary>
    public sealed class ImitatedPoseTracker :
        IPoseTrackerConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedPoseTracker"/> singleton.
        /// </summary>
        public static ImitatedPoseTracker Instance { get; } = new ImitatedPoseTracker();

        private ImitatedPoseTracker()
        {

        }

        /// <inheritdoc/>
        public IGeneration<Space3D.Position> Position { get; } = Generate.Signal(() => Space3D.Position.Origin);

        /// <inheritdoc/>
        public IGeneration<Space3D.Rotation> Rotation { get; } = Generate.Signal(() => Space3D.Rotation.None);
    }
}
