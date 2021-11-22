using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedTriggerHardware"/> and <see cref="IPulsatedTriggerSoftware"/>.
    /// </summary>
    public interface IPulsatedTriggerProtocol :
        IProtocol<IPulsatedTriggerHardware, IPulsatedTriggerSoftware>

    {
        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Pulse> Touch { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Pull"/>.
        /// </summary>
        IPropagation<Pulse> Pull { get; }
    }
}
