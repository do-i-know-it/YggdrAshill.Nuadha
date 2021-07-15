using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for stick pulsated.
    /// </summary>
    public interface IPulsatedStickHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltHardwareHandler"/> of <see cref="Signals.Touch"/> for hardware.
        /// </summary>
        IPulsatedTiltHardwareHandler Tilt { get; }
    }
}
