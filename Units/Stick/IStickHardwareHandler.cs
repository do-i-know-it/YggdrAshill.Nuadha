using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for stick.
    /// </summary>
    public interface IStickHardwareHandler :
        IHandler
    {
        /// <summary>
        /// Receives <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Touch> Touch { get; }

        /// <summary>
        /// Receives <see cref="Signals.Tilt"/> sent from hardware.
        /// </summary>
        IConsumption<Tilt> Tilt { get; }
    }
}
