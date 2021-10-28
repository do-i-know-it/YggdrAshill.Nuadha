using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated trigger as hardware.
    /// </summary>
    public interface IPulsatedTriggerHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Pull"/> to software.
        /// </summary>
        IProduction<Pulse> Pull { get; }
    }
}
