using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerCalibration
    {
        IGeneration<Position> Position { get; }

        IGeneration<Rotation> Rotation { get; }
    }
}
