using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IHeadTrackerConfiguration
    {
        IPoseTrackerConfiguration Pose { get; }

        IGeneration<Space3D.Direction> Direction { get; }
    }
}
