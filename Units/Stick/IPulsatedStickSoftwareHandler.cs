using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedStickSoftwareHandler :
        IHandler
    {
        IProduction<Pulse> Touch { get; }

        IPulsatedTiltSoftwareHandler Tilt { get; }
    }
}
