using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated <see cref="Signals.Tilt"/> as software.
    /// </summary>
    public interface IPulsatedTiltSoftware :
        IModule
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Tilt.Distance"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Distance { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Tilt.Left"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Left { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Tilt.Right"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Right { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Tilt.Forward"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Forward { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Tilt.Backward"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Backward { get; }
    }
}
