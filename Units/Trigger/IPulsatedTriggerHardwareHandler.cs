using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for trigger pulsated.
    /// </summary>
    public interface IPulsatedTriggerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Pull"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Pull { get; }
    }
}
