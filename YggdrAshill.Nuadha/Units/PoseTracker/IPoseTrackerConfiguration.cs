using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerConfiguration
    {
        ISource<Position> Position { get; }

        ISource<Rotation> Rotation { get; }
    }
}
