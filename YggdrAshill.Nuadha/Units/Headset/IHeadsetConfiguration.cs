using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IHeadsetConfiguration
    {
        IGenerator<Direction> Direction { get; }

        IPoseTrackerConfiguration PoseTracker { get; }

        IEyeTrackerConfiguration LeftEye { get; }

        IEyeTrackerConfiguration RightEye { get; }
    }
}
