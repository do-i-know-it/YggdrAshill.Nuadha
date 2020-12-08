using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerConfiguration
    {
        ISource<Position> Position { get; }

        ISource<Rotation> Rotation { get; }
    }
}
