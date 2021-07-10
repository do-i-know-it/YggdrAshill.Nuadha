using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedButtonHardwareHandler :
        IHandler
    {
        IConsumption<Pulse> Touch { get; }

        IConsumption<Pulse> Push { get; }
    }
}
