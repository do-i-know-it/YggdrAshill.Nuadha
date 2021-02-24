using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IStickConfiguration
    {
        IProduction<Touch> Touch { get; }

        IProduction<Tilt> Tilt { get; }
    }
}
