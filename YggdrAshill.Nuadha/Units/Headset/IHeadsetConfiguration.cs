using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IHeadsetConfiguration
    {
        IProduction<Direction> Direction { get; }

        IPoseTrackerConfiguration PoseTracker { get; }

        IEyeTrackerConfiguration LeftEye { get; }

        IEyeTrackerConfiguration RightEye { get; }
    }
}
