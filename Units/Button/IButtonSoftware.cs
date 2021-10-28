using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for button as software.
    /// </summary>
    public interface IButtonSoftware :
        IModule
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
