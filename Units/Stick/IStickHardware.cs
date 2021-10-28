using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for stick as hardware.
    /// </summary>
    public interface IStickHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Touch> Touch { get; }

        /// <summary>
        /// Sends <see cref="Signals.Tilt"/> to software.
        /// </summary>
        IProduction<Tilt> Tilt { get; }
    }
}
