using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedButtonHardware"/> and <see cref="IPulsatedButtonSoftware"/>.
    /// </summary>
    public interface IPulsatedButtonProtocol :
        IModule,
        IProtocol<IPulsatedButtonHardware, IPulsatedButtonSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Touch"/>.
        /// </summary>
        IPropagation<Pulse> Touch { get; }

        /// <summary>
        /// Propagates <see cref="Pulse"/> of <see cref="Signals.Push"/>.
        /// </summary>
        IPropagation<Pulse> Push { get; }
    }
}
