using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IPoseTrackerSoftware :
        IHandler
    {
        IConsumption<Space3D.Position> Position { get; }

        IConsumption<Space3D.Rotation> Rotation { get; }
    }
}
