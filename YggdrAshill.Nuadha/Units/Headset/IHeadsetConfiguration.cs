using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IHeadsetConfiguration
    {
        IGeneration<Direction> Direction { get; }

        IPoseTrackerConfiguration PoseTracker { get; }
    }
}
