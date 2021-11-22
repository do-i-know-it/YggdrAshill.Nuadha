using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IButtonHardware"/> and <see cref="IButtonSoftware"/>.
    /// </summary>
    public interface IButtonProtocol :
        IProtocol<IButtonHardware, IButtonSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Touch> Touch { get; }

        /// <summary>
        /// Propagates <see cref="Signals.Push"/>.
        /// </summary>
        IPropagation<Push> Push { get; }
    }
}
