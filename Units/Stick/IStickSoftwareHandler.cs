using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for stick.
    /// </summary>
    public interface IStickSoftwareHandler :
        IHandler
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
