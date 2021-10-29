using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for trigger as software.
    /// </summary>
    public interface ITriggerSoftware :
        IModule
    {
        /// <summary>
        /// Receives <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Touch> Touch { get; }

        /// <summary>
        /// Receives <see cref="Signals.Pull"/> sent from hardware.
        /// </summary>
        IConsumption<Pull> Pull { get; }
    }
}
