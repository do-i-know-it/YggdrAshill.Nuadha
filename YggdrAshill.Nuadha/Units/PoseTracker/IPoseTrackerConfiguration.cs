using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPoseTrackerConfiguration
    {
        IGeneration<Space3D.Position> Position { get; }

        IGeneration<Space3D.Rotation> Rotation { get; }
    }
}
