using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerHardwareHandler :
        IHardwareHandler
    {
        IInputTerminal<Position> Position { get; }

        IInputTerminal<Rotation> Rotation { get; }
    }
}
