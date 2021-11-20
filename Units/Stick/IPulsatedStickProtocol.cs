using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedStickHardware"/> and <see cref="IPulsatedStickSoftware"/>.
    /// </summary>
    public interface IPulsatedStickProtocol :
        IModule,
        IProtocol<IPulsatedStickHardware, IPulsatedStickSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IPulsatedTiltProtocol"/> of stick.
        /// </summary>
        IPulsatedTiltProtocol Tilt { get; }
    }
}
