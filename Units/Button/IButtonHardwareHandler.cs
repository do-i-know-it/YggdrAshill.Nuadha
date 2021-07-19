using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for button.
    /// </summary>
    public interface IButtonHardwareHandler :
        IHandler
    {
        /// <summary>
        /// Receives <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Touch> Touch { get; }

        /// <summary>
        /// Receives <see cref="Signals.Push"/> sent from hardware.
        /// </summary>
        IConsumption<Push> Push { get; }
    }
}
