using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerConfiguration
    {
        IGenerator<Position> Position { get; }

        IGenerator<Rotation> Rotation { get; }
    }
}
