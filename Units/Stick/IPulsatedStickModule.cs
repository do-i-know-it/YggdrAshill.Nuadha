using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedStickModule
    {
        IPropagation<Pulse> Touch { get; }

        IPulsatedTiltModule Tilt { get; }
    }
}
