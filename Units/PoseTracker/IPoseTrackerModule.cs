using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerModule
    {
        IPropagation<Space3D.Position> Position { get; }

        IPropagation<Space3D.Rotation> Rotation { get; }
    }
}
