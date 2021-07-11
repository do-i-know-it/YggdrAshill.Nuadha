using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerModule
    {
        IPoseTrackerModule Pose { get; }

        IPropagation<Space3D.Direction> Direction { get; }
    }
}
