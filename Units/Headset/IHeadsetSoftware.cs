using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetSoftware :
        ISoftware
    {
        IConsumption<Direction> Direction { get; }

        IPoseTrackerSoftware PoseTracker { get; }
    }
}
