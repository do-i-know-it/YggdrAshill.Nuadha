using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerConfiguration
    {
        IPoseTrackerConfiguration Pose { get; }

        IGeneration<Space3D.Direction> Direction { get; }
    }
}
