using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedButtonSoftwareHandler :
        IHandler
    {
        IProduction<Pulse> Touch { get; }

        IProduction<Pulse> Push { get; }
    }
}
