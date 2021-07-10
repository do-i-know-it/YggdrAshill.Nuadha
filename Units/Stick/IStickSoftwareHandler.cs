using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickSoftwareHandler :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Tilt> Tilt { get; }
    }
}
