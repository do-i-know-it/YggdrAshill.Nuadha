using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerSoftware :
        ISoftware
    {
        IConsumption<Position> Position { get; }

        IConsumption<Rotation> Rotation { get; }
    }
}
