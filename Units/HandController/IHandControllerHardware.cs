using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHardware"/> for hand controller.
    /// </summary>
    public interface IHandControllerHardware :
        IHardware
    {
        /// <summary>
        /// Sends <see cref="Signals.Battery"/> to <see cref="IHandControllerSoftware"/>.
        /// </summary>
        IProduction<Battery> Battery { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> to <see cref="IHandControllerSoftware"/>.
        /// </summary>
        IProduction<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Sends <see cref="Stick"/> of thumb to <see cref="IHandControllerSoftware"/>.
        /// </summary>
        IProduction<Stick> Thumb { get; }

        /// <summary>
        /// Sends <see cref="Trigger"/> of index finger to <see cref="IHandControllerSoftware"/>.
        /// </summary>
        IProduction<Trigger> IndexFinger { get; }

        /// <summary>
        /// Sends <see cref="Trigger"/> of hand grip to <see cref="IHandControllerSoftware"/>.
        /// </summary>
        IProduction<Trigger> HandGrip { get; }
    }
}
