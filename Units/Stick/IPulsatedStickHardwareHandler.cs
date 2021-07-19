using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for stick pulsated.
    /// </summary>
    public interface IPulsatedStickHardwareHandler :
        IHandler
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltHardwareHandler"/> of stick.
        /// </summary>
        IPulsatedTiltHardwareHandler Tilt { get; }
    }
}
