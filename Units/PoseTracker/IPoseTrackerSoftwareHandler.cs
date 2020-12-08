using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Position> Position { get; }

        IOutputTerminal<Rotation> Rotation { get; }
    }
}
