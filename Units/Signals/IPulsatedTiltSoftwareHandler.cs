using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for <see cref="Signals.Tilt"/> pulsated.
    /// </summary>
    public interface IPulsatedTiltSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Tilt.Distance"/> to software.
        /// </summary>
        IProduction<Pulse> Distance { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Tilt.Left"/> to software.
        /// </summary>
        IProduction<Pulse> Left { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Tilt.Right"/> to software.
        /// </summary>
        IProduction<Pulse> Right { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Tilt.Upward"/> to software.
        /// </summary>
        IProduction<Pulse> Forward { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Tilt.Downward"/> to software.
        /// </summary>
        IProduction<Pulse> Backward { get; }
    }
}
