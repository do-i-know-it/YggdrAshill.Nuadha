using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for button as hardware.
    /// </summary>
    public interface IButtonHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Touch> Touch { get; }

        /// <summary>
        /// Sends <see cref="Signals.Push"/> to software.
        /// </summary>
        IProduction<Push> Push { get; }
    }
}
