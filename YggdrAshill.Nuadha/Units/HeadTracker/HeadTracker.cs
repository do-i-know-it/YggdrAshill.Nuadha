using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class HeadTracker :
        IHeadTracker
    {
        public IPoseTracker Pose { get; }

        public ITransmission<Space3D.Direction> Direction { get; }

        internal HeadTracker(IHeadTrackerConfiguration configuration)
        {
            Pose = new PoseTracker(configuration.Pose);

            Direction = new PropagationWithoutCache<Space3D.Direction>().Transmit(configuration.Direction);
        }
    }
}
