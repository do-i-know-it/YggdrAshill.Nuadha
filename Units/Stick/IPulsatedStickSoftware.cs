using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated stick as software.
    /// </summary>
    public interface IPulsatedStickSoftware :
        IModule
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltSoftware"/> of stick.
        /// </summary>
        IPulsatedTiltSoftware Tilt { get; }
    }
}
