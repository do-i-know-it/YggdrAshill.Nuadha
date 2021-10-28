using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated button as hardware.
    /// </summary>
    public interface IPulsatedButtonHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Push"/> to software.
        /// </summary>
        IProduction<Pulse> Push { get; }
    }
}
