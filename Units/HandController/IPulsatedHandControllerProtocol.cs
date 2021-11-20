using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedHandControllerHardware"/> and <see cref="IPulsatedHandControllerSoftware"/>.
    /// </summary>
    public interface IPulsatedHandControllerProtocol :
        IModule,
        IProtocol<IPulsatedHandControllerHardware, IPulsatedHandControllerSoftware>
    {
        /// <summary>
        /// <see cref="IPulsatedStickProtocol"/> of hand controller.
        /// </summary>
        IPulsatedStickProtocol Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerProtocol"/> of hand controller.
        /// </summary>
        IPulsatedTriggerProtocol IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerProtocol"/> of hand controller.
        /// </summary>
        IPulsatedTriggerProtocol HandGrip { get; }
    }
}
