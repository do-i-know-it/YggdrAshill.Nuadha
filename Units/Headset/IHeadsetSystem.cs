using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetSystem :
        ISystem
    {
        IConsumption<Direction> Direction { get; }

        IPoseTrackerSystem PoseTracker { get; }
    }
}
