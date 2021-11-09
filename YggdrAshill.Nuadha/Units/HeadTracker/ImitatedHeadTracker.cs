using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedHeadTracker :
        IHeadTrackerConfiguration
    {
        public static ImitatedHeadTracker Instance { get; } = new ImitatedHeadTracker();

        private ImitatedHeadTracker()
        {

        }

        /// <inheritdoc/>
        public IPoseTrackerConfiguration Pose { get; } = ImitatedPoseTracker.Instance;

        /// <inheritdoc/>
        public IGeneration<Space3D.Direction> Direction { get; } = Generate.Signal(() => Space3D.Direction.Forward);
    }
}
