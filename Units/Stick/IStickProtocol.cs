using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IStickHardware"/> and <see cref="IStickSoftware"/>.
    /// </summary>
    public interface IStickProtocol :
        IModule,
        IProtocol<IStickHardware, IStickSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Touch> Touch { get; }

        /// <summary>
        /// Propagates <see cref="Signals.Tilt"/>.
        /// </summary>
        IPropagation<Tilt> Tilt { get; }
    }
}
