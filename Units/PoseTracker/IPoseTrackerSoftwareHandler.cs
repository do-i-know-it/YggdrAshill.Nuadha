using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IConnection<Position> Position { get; }

        IConnection<Rotation> Rotation { get; }
    }
}
