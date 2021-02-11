using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerCalculation
    {
        ICalculation<Position> Position { get; }

        ICalculation<Rotation> Rotation { get; }
    }
}
