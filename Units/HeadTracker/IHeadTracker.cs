using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTracker
    {
        IPoseTracker Pose { get; }

        ITransmission<Space3D.Direction> Direction { get; }
    }
}
