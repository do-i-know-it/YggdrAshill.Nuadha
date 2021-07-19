using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for stick pulsated.
    /// </summary>
    public interface IPulsatedStickSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltSoftwareHandler"/> of stick.
        /// </summary>
        IPulsatedTiltSoftwareHandler Tilt { get; }
    }
}
