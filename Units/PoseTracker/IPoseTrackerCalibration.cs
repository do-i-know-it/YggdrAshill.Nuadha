using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerCalibration
    {
        ICalibration<Position> Position { get; }

        ICalibration<Rotation> Rotation { get; }
    }
}
