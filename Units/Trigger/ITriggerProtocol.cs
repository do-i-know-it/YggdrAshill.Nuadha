using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="ITriggerHardware"/> and <see cref="ITriggerSoftware"/>.
    /// </summary>
    public interface ITriggerProtocol :
        IProtocol<ITriggerHardware, ITriggerSoftware>

    {
        /// <summary>
        /// Propagates <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Touch> Touch { get; }

        /// <summary>
        /// Propagates <see cref="Signals.Pull"/>.
        /// </summary>
        IPropagation<Pull> Pull { get; }
    }
}
