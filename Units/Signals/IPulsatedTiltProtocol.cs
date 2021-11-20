using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedTiltHardware"/> and <see cref="IPulsatedTiltSoftware"/>.
    /// </summary>
    public interface IPulsatedTiltProtocol :
        IModule,
        IProtocol<IPulsatedTiltHardware, IPulsatedTiltSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Tilt.Distance"/>.
        /// </summary>
        IPropagation<Pulse> Distance { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Tilt.Left"/>.
        /// </summary>
        IPropagation<Pulse> Left { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Tilt.Right"/>.
        /// </summary>
        IPropagation<Pulse> Right { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Tilt.Forward"/>.
        /// </summary>
        IPropagation<Pulse> Forward { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Tilt.Backward"/>.
        /// </summary>
        IPropagation<Pulse> Backward { get; }
    }
}
