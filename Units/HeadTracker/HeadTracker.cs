using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class HeadTracker :
        IHeadTracker
    {
        public IPoseTracker Pose { get; }

        public ITransmission<Space3D.Direction> Direction { get; }

        internal HeadTracker(IHeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            Pose = new PoseTracker(module.Pose, configuration.Pose);

            Direction = module.Direction.Transmit(configuration.Direction);
        }
    }
}
