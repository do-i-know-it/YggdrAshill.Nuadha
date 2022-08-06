using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public interface IHandControllerModule :
        IModule<IHandControllerHardware, IHandControllerSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Signals.Battery"/>.
        /// </summary>
        IPropagation<Battery> Battery { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Pose"/>.
        /// </summary>
        IPropagation<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Propagates <see cref="Stick"/> of thumb.
        /// </summary>
        IPropagation<Stick> Thumb { get; }

        /// <summary>
        /// Propagates <see cref="Trigger"/> of index finger.
        /// </summary>
        IPropagation<Trigger> IndexFinger { get; }

        /// <summary>
        /// Propagates <see cref="Trigger"/> of hand grip.
        /// </summary>
        IPropagation<Trigger> HandGrip { get; }
    }
}
