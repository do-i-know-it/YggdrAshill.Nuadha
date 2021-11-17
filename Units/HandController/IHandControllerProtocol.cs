using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public interface IHandControllerProtocol :
        IModule,
        IProtocol<IHandControllerHardware, IHandControllerSoftware>
    {
        /// <summary>
        /// <see cref="IPoseTrackerProtocol"/> of hand controller.
        /// </summary>
        IPoseTrackerProtocol Pose { get; }

        /// <summary>
        /// <see cref="IStickProtocol"/> of hand controller.
        /// </summary>
        IStickProtocol Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> of hand controller.
        /// </summary>
        ITriggerProtocol IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> of hand controller.
        /// </summary>
        ITriggerProtocol HandGrip { get; }
    }
}
