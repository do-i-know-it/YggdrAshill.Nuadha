using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Monitorization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="ISoftware"/> for hand controller.
    /// </summary>
    public interface IHandControllerSoftware :
        ISoftware
    {
        /// <summary>
        /// Receives <see cref="Monitorization.Battery"/> sent from <see cref="IHandControllerHardware"/>.
        /// </summary>
        IConsumption<Battery> Battery { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> sent from <see cref="IHandControllerHardware"/>.
        /// </summary>
        IConsumption<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Receives <see cref="Stick"/> of thumb sent from <see cref="IHandControllerHardware"/>.
        /// </summary>
        IConsumption<Stick> Thumb { get; }

        /// <summary>
        /// Receives <see cref="Trigger"/> of index finger sent from <see cref="IHandControllerHardware"/>.
        /// </summary>
        IConsumption<Trigger> IndexFinger { get; }

        /// <summary>
        /// Receives <see cref="Trigger"/> of hand grip sent from <see cref="IHandControllerHardware"/>.
        /// </summary>
        IConsumption<Trigger> HandGrip { get; }
    }
}
