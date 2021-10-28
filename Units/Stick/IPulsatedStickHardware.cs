using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated stick as hardware.
    /// </summary>
    public interface IPulsatedStickHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltHardware"/> of stick.
        /// </summary>
        IPulsatedTiltHardware Tilt { get; }
    }
}
