using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedPoseTracker :
        IPoseTrackerConfiguration
    {
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
