using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerSoftwareHandler :
        IDevice
    {
        IConnection<Position> Position { get; }

        IConnection<Rotation> Rotation { get; }
    }
}
