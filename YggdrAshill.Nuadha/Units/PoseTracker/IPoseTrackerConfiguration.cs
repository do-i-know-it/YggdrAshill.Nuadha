using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerConfiguration
    {
        IProduction<Position> Position { get; }

        IProduction<Rotation> Rotation { get; }
    }
}
