using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTracker
    {
        ITransmission<Space3D.Position> Position { get; }

        ITransmission<Space3D.Rotation> Rotation { get; }
    }
}
