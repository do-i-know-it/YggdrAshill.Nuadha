using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for trigger as hardware.
    /// </summary>
    public interface ITriggerHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Touch> Touch { get; }

        /// <summary>
        /// Sends <see cref="Signals.Pull"/> to software.
        /// </summary>
        IProduction<Pull> Pull { get; }
    }
}
