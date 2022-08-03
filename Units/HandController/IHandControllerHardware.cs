using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for hand controller as hardware.
    /// </summary>
    public interface IHandControllerHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> to software.
        /// </summary>
        IProduction<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Sends <see cref="Stick"/> of thumb to software.
        /// </summary>
        IProduction<Stick> Thumb { get; }

        /// <summary>
        /// Sends <see cref="Trigger"/> of index finger to software.
        /// </summary>
        IProduction<Trigger> IndexFinger { get; }

        /// <summary>
        /// Sends <see cref="Trigger"/> of hand grip to software.
        /// </summary>
        IProduction<Trigger> HandGrip { get; }
    }
}
