using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for hand controller as software.
    /// </summary>
    public interface IHandControllerSoftware :
        IModule
    {
        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Receives <see cref="Stick"/> of thumb sent from hardware.
        /// </summary>
        IConsumption<Stick> Thumb { get; }

        /// <summary>
        /// Receives <see cref="Trigger"/> of index finger sent from hardware.
        /// </summary>
        IConsumption<Trigger> IndexFinger { get; }

        /// <summary>
        /// Receives <see cref="Trigger"/> of hand grip sent from hardware.
        /// </summary>
        IConsumption<Trigger> HandGrip { get; }
    }
}
